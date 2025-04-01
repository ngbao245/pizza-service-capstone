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

            var workingSlotRegisters = await _workingSlotRegisterRepository.GetListAsTracking(
                x => x.StaffId == staffId && x.WorkingDate == workingDate).ToListAsync();
            if (workingSlotRegisters == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);

            var workingSlotRegister = workingSlotRegisters.FirstOrDefault(x => x.WorkingSlotId == workingSlotId);
            if (workingSlotRegister == null) throw new BusinessException($"Nhân viên chưa đăng ký ca {workingSlot.ShiftName} vào ngày {workingDate:yyyy-MM-dd}");

            var zone = await _zoneRepository.GetSingleByIdAsync(zoneId);
            if (zone == null) throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);

            var existingSchedule = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.WorkingDate == workingDate && x.WorkingSlotId == workingSlotId && x.ZoneId == zoneId);
            if (existingSchedule != null)
                throw new BusinessException($"Nhân viên đã được phân công vào khu vực {existingSchedule.ZoneName} cho ngày {workingDate:yyyy-MM-dd} khung giờ {workingSlot.ShiftStart}-{workingSlot.ShiftEnd}");

            var staffZoneSchedule = new StaffZoneSchedule(Guid.NewGuid(), staff.FullName, zone.Name, workingDate, staffId, zoneId, workingSlotId);
            _staffZoneScheduleRepository.Add(staffZoneSchedule);
            workingSlotRegister.ZoneId = zoneId;
            await _unitOfWork.SaveChangeAsync();
            return staffZoneSchedule.Id;
        }

        public async Task AutoAssignZoneAsync(DateOnly workingDate)
        {
            // Lấy danh sách nhân viên part-time đã đăng ký ca
            var workingSlotRegisters = await _workingSlotRegisterRepository.GetListAsTracking(
                x => x.WorkingDate == workingDate && x.Status == WorkingSlotRegisterStatusEnum.Approved)
                .Include(x => x.Staff)
                .Include(x => x.WorkingSlot)
                .ToListAsync();

            // Lấy danh sách nhân viên full-time
            var fullTimeStaffs = await _staffRepository.GetListAsTracking(
                x => x.Status == StaffStatusEnum.FullTime).ToListAsync();

            // Lấy danh sách khu vực làm việc
            var zones = await _zoneRepository.GetListAsTracking().ToListAsync();
            if (!zones.Any()) throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);

            var diningAreas = zones.Where(x => x.Type == ZoneTypeEnum.DininingArea).ToList();
            var kitchenAreas = zones.Where(x => x.Type == ZoneTypeEnum.KitchenArea).ToList();

            // Nhóm nhân viên theo loại công việc
            var approvedStaffList = workingSlotRegisters.Where(x => x.Staff.StaffType == StaffTypeEnum.Staff).ToList();
            var approvedChefList = workingSlotRegisters.Where(x => x.Staff.StaffType == StaffTypeEnum.Cheff).ToList();

            var staffZoneSchedules = new List<StaffZoneSchedule>();

            // Lấy danh sách tất cả các ca trong ngày
            var workingSlots = await _workingSlotRepository.GetListAsTracking().OrderBy(x => x.ShiftStart).ToListAsync();
            foreach (var slot in workingSlots)
            {
                var previousAssignments = staffZoneSchedules
                    .Where(x => x.WorkingDate == workingDate && x.WorkingSlotId != slot.Id)
                    .GroupBy(x => x.StaffId)
                    .ToDictionary(g => g.Key, g => g.OrderByDescending(s => s.WorkingSlotId).First().ZoneId);

                var partTimeStaffsInSlot = approvedStaffList.Where(x => x.WorkingSlotId == slot.Id).Select(x => x.Staff).ToList();
                var chefsInSlot = approvedChefList.Where(x => x.WorkingSlotId == slot.Id).Select(x => x.Staff).ToList();

                var fullTimeStaffsInSlot = fullTimeStaffs.Where(x => !staffZoneSchedules.Any(y => y.StaffId == x.Id)).ToList();

                // Phân công khu vực cho nhân viên phục vụ
                AssignZones(partTimeStaffsInSlot.Concat(fullTimeStaffsInSlot).ToList(), diningAreas, staffZoneSchedules, workingDate, slot.Id, previousAssignments);

                // Phân công khu vực cho bếp trưởng
                AssignZones(chefsInSlot.Concat(fullTimeStaffs.Where(x => x.StaffType == StaffTypeEnum.Cheff)).ToList(), kitchenAreas, staffZoneSchedules, workingDate, slot.Id, previousAssignments);
            }

            _staffZoneScheduleRepository.AddRange(staffZoneSchedules);
            await _unitOfWork.SaveChangeAsync();
        }

        private void AssignZones(
            List<Staff> staffList,
            List<Zone> availableZones,
            List<StaffZoneSchedule> staffZoneSchedules,
            DateOnly workingDate,
            Guid workingSlotId,
            Dictionary<Guid, Guid> previousAssignments)
        {
            foreach (var staff in staffList)
            {
                Guid assignedZoneId;

                if (previousAssignments.TryGetValue(staff.Id, out assignedZoneId) && availableZones.Any(z => z.Id == assignedZoneId))
                {
                    // Giữ nguyên khu vực từ ca trước nếu còn tồn tại
                }
                else
                {
                    assignedZoneId = availableZones.OrderBy(z => staffZoneSchedules.Count(s => s.ZoneId == z.Id)).FirstOrDefault()?.Id ?? Guid.Empty;
                }

                if (assignedZoneId == Guid.Empty) continue;

                staffZoneSchedules.Add(new StaffZoneSchedule(
                    Guid.NewGuid(),
                    staff.FullName,
                    availableZones.First(z => z.Id == assignedZoneId).Name,
                    workingDate,
                    staff.Id,
                    assignedZoneId,
                    workingSlotId));
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
