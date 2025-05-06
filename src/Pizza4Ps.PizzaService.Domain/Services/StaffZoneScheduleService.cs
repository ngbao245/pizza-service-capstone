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
        private readonly IConfigRepository _configRepository;

        public StaffZoneScheduleService(
            IUnitOfWork unitOfWork,
            IStaffZoneScheduleRepository staffZoneScheduleRepository,
            IWorkingSlotRegisterRepository workingSlotRegisterRepository,
            IZoneRepository zoneRepository,
            IWorkingSlotRepository workingSlotRepository,
            IStaffRepository staffRepository,
            IConfigRepository configRepository)
        {
            _unitOfWork = unitOfWork;
            _staffZoneScheduleRepository = staffZoneScheduleRepository;
            _workingSlotRegisterRepository = workingSlotRegisterRepository;
            _zoneRepository = zoneRepository;
            _workingSlotRepository = workingSlotRepository;
            _staffRepository = staffRepository;
            _configRepository = configRepository;
        }

        public async Task<Guid> CreateAsync(DateOnly workingDate, Guid staffId, Guid zoneId, Guid workingSlotId)
        {
            var staff = await _staffRepository.GetSingleByIdAsync(staffId);
            if (staff == null) throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);

            var workingSlot = await _workingSlotRepository.GetSingleByIdAsync(workingSlotId);
            if (workingSlot == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);

            var workingSlotRegisters = await _workingSlotRegisterRepository.GetListAsTracking(
                x => x.StaffId == staffId && x.WorkingDate == workingDate).ToListAsync();
            //if (workingSlotRegisters == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);

            var workingSlotRegister = workingSlotRegisters.FirstOrDefault(x => x.WorkingSlotId == workingSlotId);
            //if (workingSlotRegister == null) throw new BusinessException($"Nhân viên chưa đăng ký ca {workingSlot.ShiftName} vào ngày {workingDate:yyyy-MM-dd}");

            var zone = await _zoneRepository.GetSingleByIdAsync(zoneId);
            if (zone == null) throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);

            var existingSchedule = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.WorkingDate == workingDate && x.WorkingSlotId == workingSlotId && x.ZoneId == zoneId);
            if (existingSchedule != null)
                throw new BusinessException($"Nhân viên đã được phân công vào khu vực {existingSchedule.ZoneName} cho ngày {workingDate:yyyy-MM-dd} khung giờ {workingSlot.ShiftStart.ToString(@"hh\:mm")}-{workingSlot.ShiftEnd.ToString(@"hh\:mm")}");

            var staffZoneSchedule = new StaffZoneSchedule(Guid.NewGuid(), staff.FullName, zone.Name, workingDate, staffId, zoneId, workingSlotId);
            _staffZoneScheduleRepository.Add(staffZoneSchedule);

            if (workingSlotRegister != null)
            {
                workingSlotRegister.ZoneId = zoneId;
                workingSlotRegister.setApproved();
            }

            await _unitOfWork.SaveChangeAsync();
            return staffZoneSchedule.Id;
        }

        public async Task AutoAssignZoneForWeekJobAsync()
        {
            var config = await _configRepository.GetSingleAsync(x => x.ConfigType == ConfigType.REGISTRATION_CUTOFF_DAY);
            int cutoffDays = int.Parse(config.Value);

            var vietnamTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "SE Asia Standard Time");
            var nextMonday = vietnamTime.Date.AddDays(7 - (int)vietnamTime.DayOfWeek + (int)DayOfWeek.Monday);
            var startDate = DateOnly.FromDateTime(nextMonday);

            var staffZoneSchedules = new List<StaffZoneSchedule>();
            var assignedZones = new Dictionary<Guid, Guid>();
            var zoneCapacity = new Dictionary<Guid, int>();

            //check duplicate
            var endDate = startDate.AddDays(7);
            var existingSchedules = await _staffZoneScheduleRepository
                .GetListAsTracking(x => x.WorkingDate >= startDate && x.WorkingDate < endDate)
                .ToListAsync();

            //

            for (int i = 0; i < 7; i++)
            {
                var workingDate = startDate.AddDays(i);
                var workingSlots = await _workingSlotRepository.GetListAsTracking().OrderBy(x => x.ShiftStart).ToListAsync();
                if (!workingSlots.Any()) continue;

                var zones = await _zoneRepository.GetListAsTracking().ToListAsync();
                if (!zones.Any()) throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);

                var diningAreas = zones.Where(x => x.Type == ZoneTypeEnum.DininingArea).ToList();
                var kitchenAreas = zones.Where(x => x.Type == ZoneTypeEnum.KitchenArea).ToList();

                var fullTimeStaffs = await _staffRepository.GetListAsTracking(x => x.Status == StaffStatusEnum.FullTime).ToListAsync();
                var partTimeRegistrations = await _workingSlotRegisterRepository.GetListAsTracking(
                    x => x.WorkingDate == workingDate && x.Status == WorkingSlotRegisterStatusEnum.Approved)
                    .Include(x => x.Staff)
                    .Include(x => x.WorkingSlot)
                    .ToListAsync();

                AssignFullTimeZones(fullTimeStaffs, diningAreas, kitchenAreas, assignedZones, zoneCapacity, staffZoneSchedules, existingSchedules, workingDate);

                foreach (var slot in workingSlots)
                {
                    AssignZones(partTimeRegistrations.Where(x => x.WorkingSlotId == slot.Id).Select(x => x.Staff).ToList(),
                        diningAreas, kitchenAreas, staffZoneSchedules, assignedZones, zoneCapacity, existingSchedules, workingDate, slot.Id);
                }
            }
            _staffZoneScheduleRepository.AddRange(staffZoneSchedules);

            foreach (var schedule in staffZoneSchedules)
            {
                var workingSlotRegister = await _workingSlotRegisterRepository.GetSingleAsync(
                    x => x.StaffId == schedule.StaffId
                      && x.WorkingDate == schedule.WorkingDate
                      && x.WorkingSlotId == schedule.WorkingSlotId);

                if (workingSlotRegister != null)
                {
                    workingSlotRegister.ZoneId = schedule.ZoneId;
                }
            }

            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AutoAssignZoneForWeekAsync(DateOnly startDate)
        {
            if (startDate.DayOfWeek != DayOfWeek.Monday) throw new BusinessException(BussinessErrorConstants.DayErrorConstant.INVALID_START_DATE);

            var staffZoneSchedules = new List<StaffZoneSchedule>();
            var assignedZones = new Dictionary<Guid, Guid>();
            var zoneCapacity = new Dictionary<Guid, int>();

            //check duplicate
            var endDate = startDate.AddDays(7);
            var existingSchedules = await _staffZoneScheduleRepository
                .GetListAsTracking(x => x.WorkingDate >= startDate && x.WorkingDate < endDate)
                .ToListAsync();

            //

            for (int i = 0; i < 7; i++)
            {
                var workingDate = startDate.AddDays(i);
                var workingSlots = await _workingSlotRepository.GetListAsTracking().OrderBy(x => x.ShiftStart).ToListAsync();
                if (!workingSlots.Any()) continue;

                var zones = await _zoneRepository.GetListAsTracking().ToListAsync();
                if (!zones.Any()) throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);

                var diningAreas = zones.Where(x => x.Type == ZoneTypeEnum.DininingArea).ToList();
                var kitchenAreas = zones.Where(x => x.Type == ZoneTypeEnum.KitchenArea).ToList();

                var fullTimeStaffs = await _staffRepository.GetListAsTracking(x => x.Status == StaffStatusEnum.FullTime).ToListAsync();
                var partTimeRegistrations = await _workingSlotRegisterRepository.GetListAsTracking(
                    x => x.WorkingDate == workingDate && x.Status == WorkingSlotRegisterStatusEnum.Approved)
                    .Include(x => x.Staff)
                    .Include(x => x.WorkingSlot)
                    .ToListAsync();

                AssignFullTimeZones(fullTimeStaffs, diningAreas, kitchenAreas, assignedZones, zoneCapacity, staffZoneSchedules, existingSchedules, workingDate);

                foreach (var slot in workingSlots)
                {
                    var partTimeRegist = partTimeRegistrations.Where(x => x.WorkingSlotId == slot.Id).Select(x => x.Staff).ToList();
                    AssignZones(partTimeRegist, diningAreas, kitchenAreas, staffZoneSchedules, assignedZones, zoneCapacity, existingSchedules, workingDate, slot.Id);
                }
            }
            _staffZoneScheduleRepository.AddRange(staffZoneSchedules);

            foreach (var schedule in staffZoneSchedules)
            {
                var workingSlotRegister = await _workingSlotRegisterRepository.GetSingleAsync(
                    x => x.StaffId == schedule.StaffId
                      && x.WorkingDate == schedule.WorkingDate
                      && x.WorkingSlotId == schedule.WorkingSlotId);

                if (workingSlotRegister != null)
                {
                    workingSlotRegister.ZoneId = schedule.ZoneId;
                }
            }

            await _unitOfWork.SaveChangeAsync();
        }

        private void AssignFullTimeZones(
            List<Staff> fullTimeStaffs,
            List<Zone> diningAreas,
            List<Zone> kitchenAreas,
            Dictionary<Guid, Guid> assignedZones,
            Dictionary<Guid, int> zoneCapacity,
            List<StaffZoneSchedule> staffZoneSchedules,
            List<StaffZoneSchedule> existingSchedules,
            DateOnly workingDate)
        {
            int diningIndex = 0, kitchenIndex = 0;

            foreach (var staff in fullTimeStaffs)
            {
                if (staff.StaffType == StaffTypeEnum.Manager || staff.StaffType == StaffTypeEnum.ScreenChef || staff.StaffType == StaffTypeEnum.ScreenWaiter) continue;

                if (existingSchedules.Any(x => x.StaffId == staff.Id && x.WorkingDate == workingDate))
                    continue;

                if (!assignedZones.ContainsKey(staff.Id))
                {
                    Guid assignedZoneId;
                    if (staff.StaffType == StaffTypeEnum.Cheff)
                    {
                        assignedZoneId = kitchenAreas[kitchenIndex % kitchenAreas.Count].Id;
                        kitchenIndex++;
                    }
                    else
                    {
                        assignedZoneId = diningAreas[diningIndex % diningAreas.Count].Id;
                        diningIndex++;
                    }
                    assignedZones[staff.Id] = assignedZoneId;
                    zoneCapacity[assignedZoneId] = zoneCapacity.GetValueOrDefault(assignedZoneId, 0) + 1;
                }

                if (!staffZoneSchedules.Any(s => s.StaffId == staff.Id && s.WorkingDate == workingDate))
                {
                    staffZoneSchedules.Add(new StaffZoneSchedule(
                    id: Guid.NewGuid(),
                    staffName: staff.FullName,
                    zoneName: (staff.StaffType == StaffTypeEnum.Cheff ? kitchenAreas : diningAreas)
                        .First(x => x.Id == assignedZones[staff.Id]).Name,
                    workingDate: workingDate,
                    staffId: staff.Id,
                    zoneId: assignedZones[staff.Id],
                    workingSlotId: null));
                }
            }
        }

        private void AssignZones(
            List<Staff> staffList,
            List<Zone> diningAreas,
            List<Zone> kitchenAreas,
            List<StaffZoneSchedule> staffZoneSchedules,
            Dictionary<Guid, Guid> assignedZones,
            Dictionary<Guid, int> zoneCapacity,
            List<StaffZoneSchedule> existingSchedules,
            DateOnly workingDate,
            Guid workingSlotId)
        {
            foreach (var staff in staffList)
            {
                if (staff.StaffType == StaffTypeEnum.Manager) continue;

                if (existingSchedules.Any(
                    x => x.StaffId == staff.Id &&
                    x.WorkingDate == workingDate &&
                    x.WorkingSlotId == workingSlotId)) continue;

                if (!assignedZones.ContainsKey(staff.Id))
                {
                    Guid assignedZoneId;
                    if (!kitchenAreas.Any() && staff.StaffType == StaffTypeEnum.Cheff)
                        throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.KITCHEN_ZONE_NOT_FOUND);

                    if (!diningAreas.Any() && staff.StaffType != StaffTypeEnum.Cheff)
                        throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.DINING_ZONE_NOT_FOUND);

                    if (staff.StaffType == StaffTypeEnum.Cheff)
                    {
                        assignedZoneId = kitchenAreas.OrderBy(x => zoneCapacity.GetValueOrDefault(x.Id, 0)).First().Id;
                    }
                    else
                    {
                        assignedZoneId = diningAreas.OrderBy(x => zoneCapacity.GetValueOrDefault(x.Id, 0)).First().Id;
                    }
                    assignedZones[staff.Id] = assignedZoneId;
                    zoneCapacity[assignedZoneId] = zoneCapacity.GetValueOrDefault(assignedZoneId, 0) + 1;
                }

                if (!staffZoneSchedules.Any(s => s.StaffId == staff.Id && s.WorkingDate == workingDate && s.WorkingSlotId == workingSlotId))
                {
                    staffZoneSchedules.Add(new StaffZoneSchedule(
                    id: Guid.NewGuid(),
                    staffName: staff.FullName,
                    zoneName: (staff.StaffType == StaffTypeEnum.Cheff ? kitchenAreas : diningAreas).First(x => x.Id == assignedZones[staff.Id]).Name,
                    workingDate: workingDate,
                    staffId: staff.Id,
                    zoneId: assignedZones[staff.Id],
                    workingSlotId));
                }
            }
        }

        public async Task<Guid> UpdateZoneAsync(Guid id, Guid zoneId)
        {
            var entity = await _staffZoneScheduleRepository.GetSingleByIdAsync(id);
            if (entity == null) throw new BusinessException(BussinessErrorConstants.StaffZoneScheduleErrorConstant.STAFF_ZONE_SCHEDULE_NOT_FOUND);

            var newZone = await _zoneRepository.GetSingleByIdAsync(zoneId);
            if (newZone == null) throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);

            entity.UpdateZone(newZone.Id, newZone.Name);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _staffZoneScheduleRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
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
    }
}
