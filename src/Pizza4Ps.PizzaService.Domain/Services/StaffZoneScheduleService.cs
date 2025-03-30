using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class StaffZoneScheduleService : DomainService, IStaffZoneScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffZoneScheduleRepository _staffZoneScheduleRepository;
        private readonly IWorkingSlotRegisterRepository _workingSlotRegisterRepository;
        private readonly IZoneRepository _zoneRepository;
        private readonly IWorkingSlotRepository _workingSlotRepository;
        private readonly IStaffRepository _staffRepository;

        public StaffZoneScheduleService(
            IUnitOfWork unitOfWork,
            IStaffZoneScheduleRepository staffZoneScheduleRepository,
            IWorkingSlotRegisterRepository workingSlotRegisterRepository,
            IZoneRepository zoneRepository,
            IWorkingSlotRepository workingSlotRepository,
            IStaffRepository staffRepository)
        {
            _unitOfWork = unitOfWork;
            _staffZoneScheduleRepository = staffZoneScheduleRepository;
            _workingSlotRegisterRepository = workingSlotRegisterRepository;
            _zoneRepository = zoneRepository;
            _workingSlotRepository = workingSlotRepository;
            _staffRepository = staffRepository;
        }

        public async Task<Guid> CreateAsync(DateOnly workingDate, Guid staffId, Guid zoneId, Guid workingSlotId)
        {
            var staff = await _staffRepository.GetSingleByIdAsync(staffId);
            if (staff == null) throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);

            var workingSlot = await _workingSlotRepository.GetSingleByIdAsync(workingSlotId);
            if (workingSlot == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);

            var workingSlotRegister = await _workingSlotRegisterRepository.GetSingleAsync(
                  x => x.StaffId == staffId && x.WorkingSlotId == workingSlotId);
            if (workingSlotRegister == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);

            if (workingSlotRegister.WorkingDate != workingDate)
                throw new BusinessException($"Ngày làm việc {workingDate:yyyy-MM-dd} không khớp với ngày đăng ký {workingSlotRegister.WorkingDate:yyyy-MM-dd}");

            var zone = await _zoneRepository.GetSingleByIdAsync(zoneId);
            if (zone == null) throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);


            var existingSchedule = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.WorkingDate == workingDate && x.WorkingSlotId == workingSlotId && x.ZoneId == zoneId);
            if (existingSchedule != null)
                throw new BusinessException($"Nhân viên đã được phân công vào khu vực {existingSchedule.ZoneName} cho ngày {workingDate:yyyy-MM-dd} khung giờ {workingSlot.ShiftStart}-{workingSlot.ShiftEnd}");

            var staffZoneSchedule = new StaffZoneSchedule(Guid.NewGuid(), staff.FullName, zone.Name, workingDate, staffId, zoneId, workingSlotId);
            _staffZoneScheduleRepository.Add(staffZoneSchedule);
            if (workingSlotRegister.Status == WorkingSlotRegisterStatusEnum.Onhold)
            {
                workingSlotRegister.Status = WorkingSlotRegisterStatusEnum.Approved;
            }
            workingSlotRegister.ZoneId = zoneId;
            await _unitOfWork.SaveChangeAsync();
            return staffZoneSchedule.Id;
        }

        public async Task AutoAssignZoneAsync(DateOnly workingDate)
        {
            var workingSlotRegisters = await _workingSlotRegisterRepository.GetListAsTracking(
                x => x.WorkingDate == workingDate && x.Status == WorkingSlotRegisterStatusEnum.Approved)
                .Include(x => x.Staff)
                .Include(x => x.WorkingSlot)
                .ToListAsync();

            if (workingSlotRegisters == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);

            var zones = await _zoneRepository.GetListAsTracking().ToListAsync();
            if (zones == null) throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);

            var diningAreas = zones.Where(x => x.Type == ZoneTypeEnum.DininingArea).ToList();
            if (diningAreas == null) throw new BusinessException("DiningArea chưa được thiết lập!");
            var kitchenAreas = zones.Where(x => x.Type == ZoneTypeEnum.KitchenArea).ToList();
            if (kitchenAreas == null) throw new BusinessException("KitchenArea chưa được thiết lập!");

            var approvedStaffList = workingSlotRegisters
                .Where(x => x.Status == WorkingSlotRegisterStatusEnum.Approved && x.Staff.StaffType == StaffTypeEnum.Staff)
                .ToList();
            var approvedChefList = workingSlotRegisters
                .Where(x => x.Status == WorkingSlotRegisterStatusEnum.Approved && x.Staff.StaffType == StaffTypeEnum.Cheff)
                .ToList();

            var onHoldStaffList = workingSlotRegisters
                .Where(x => x.Status == WorkingSlotRegisterStatusEnum.Onhold && x.Staff.StaffType == StaffTypeEnum.Staff)
                .ToList();
            var onHoldChefList = workingSlotRegisters
                .Where(x => x.Status == WorkingSlotRegisterStatusEnum.Onhold && x.Staff.StaffType == StaffTypeEnum.Cheff)
                .ToList();

            var staffZoneSchedules = new List<StaffZoneSchedule>();
            var workingSlotCapacity = new Dictionary<Guid, int>();

            AssignZones(approvedStaffList, diningAreas, staffZoneSchedules, workingSlotCapacity, workingDate);
            AssignZones(approvedChefList, kitchenAreas, staffZoneSchedules, workingSlotCapacity, workingDate);

            _staffZoneScheduleRepository.AddRange(staffZoneSchedules);
            await _unitOfWork.SaveChangeAsync();
        }

        private void AssignZones(List<WorkingSlotRegister> staffList,
            List<Zone> availableZones,
            List<StaffZoneSchedule> staffZoneSchedules,
            Dictionary<Guid, int> workingSlotCapacity,
            DateOnly workingDate)
        {
            if (staffList == null) return;

            int zoneIndex = 0;
            foreach (var register in staffList)
            {
                var staff = register.Staff;
                var workingSlot = register.WorkingSlot;

                if (!workingSlotCapacity.ContainsKey(workingSlot.Id))
                {
                    workingSlotCapacity[workingSlot.Id] = 0;
                }

                if (workingSlotCapacity[workingSlot.Id] >= workingSlot.Capacity)
                {
                    return;
                }

                var assignedZone = availableZones[zoneIndex];
                staffZoneSchedules.Add(new StaffZoneSchedule(
                    Guid.NewGuid(),
                    staff.FullName,
                    assignedZone.Name,
                    workingDate,
                    staff.Id,
                    assignedZone.Id,
                    workingSlot.Id));

                workingSlotCapacity[workingSlot.Id]++;
                zoneIndex = (zoneIndex + 1) % availableZones.Count;
            }
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _staffZoneScheduleRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (!entities.Any()) throw new BusinessException(BussinessErrorConstants.StaffZoneScheduleErrorConstant.STAFF_ZONE_SCHEDULE_NOT_FOUND);

            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _staffZoneScheduleRepository.HardDelete(entity);
                }
                else
                {
                    _staffZoneScheduleRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _staffZoneScheduleRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _staffZoneScheduleRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, int dayofWeek, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId, Guid workingtimeId)
        {
            //var entity = await _staffZoneScheduleRepository.GetSingleByIdAsync(id);
            //entity. UpdateStaffZoneSchedule(staffId, zoneId, workingtimeId);
            //await _unitOfWork.SaveChangeAsync();
            //return entity.Id;
            throw new NotImplementedException();
        }
    }
}
