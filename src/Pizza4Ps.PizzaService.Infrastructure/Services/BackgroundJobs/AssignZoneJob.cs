using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Infrastructure.Services.BackgroundJobs;

public class AssignZoneJob
{
    private readonly IConfigRepository _configRepository;
    private readonly IStaffZoneScheduleRepository _staffZoneScheduleRepository;
    private readonly IZoneRepository _zoneRepository;
    private readonly IWorkingSlotRepository _workingSlotRepository;
    private readonly IStaffRepository _staffRepository;
    private readonly IWorkingSlotRegisterRepository _workingSlotRegisterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssignZoneJob(
        IConfigRepository configRepository,
        IStaffZoneScheduleRepository staffZoneScheduleRepository,
        IZoneRepository zoneRepository,
        IWorkingSlotRepository workingSlotRepository,
        IStaffRepository staffRepository,
        IWorkingSlotRegisterRepository workingSlotRegisterRepository,
        IUnitOfWork unitOfWork)
    {
        _configRepository = configRepository;
        _staffZoneScheduleRepository = staffZoneScheduleRepository;
        _zoneRepository = zoneRepository;
        _workingSlotRepository = workingSlotRepository;
        _staffRepository = staffRepository;
        _workingSlotRegisterRepository = workingSlotRegisterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine($"Auto Assign Zone to Staff Success: {DateTime.Now}");
        Console.WriteLine("============================================================");


        var config = await _configRepository.GetSingleAsync(x => x.ConfigType == ConfigType.REGISTRATION_CUTOFF_DAY);
        int cutoffDays = int.Parse(config.Value);

        var vietnamTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "SE Asia Standard Time");
        var nextMonday = vietnamTime.Date.AddDays(7 - (int)vietnamTime.DayOfWeek + (int)DayOfWeek.Monday);
        var startDate = DateOnly.FromDateTime(nextMonday);

        var staffZoneSchedules = new List<StaffZoneSchedule>();
        var assignedZones = new Dictionary<Guid, Guid>();
        var zoneCapacity = new Dictionary<Guid, int>();

        // Xóa lịch đã tồn tại trong tuần tới
        var endDate = startDate.AddDays(7);
        var oldSchedules = await _staffZoneScheduleRepository
            .GetListAsTracking(x => x.WorkingDate >= startDate && x.WorkingDate < endDate)
            .ToListAsync();

        foreach (var oldSchedule in oldSchedules)
        {
            _staffZoneScheduleRepository.SoftDelete(oldSchedule);
        }

        for (int i = 0; i < 7; i++)
        {
            var workingDate = startDate.AddDays(i);
            var workingSlots = await _workingSlotRepository.GetListAsTracking()
                .OrderBy(x => x.ShiftStart)
                .ToListAsync();
            if (!workingSlots.Any()) continue;

            var zones = await _zoneRepository.GetListAsTracking().ToListAsync();
            if (!zones.Any()) throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);

            var diningAreas = zones.Where(x => x.Type == ZoneTypeEnum.DininingArea).ToList();
            var kitchenAreas = zones.Where(x => x.Type == ZoneTypeEnum.KitchenArea).ToList();

            var fullTimeStaffs = await _staffRepository
                .GetListAsTracking(x => x.Status == StaffStatusEnum.FullTime)
                .ToListAsync();

            var partTimeRegistrations = await _workingSlotRegisterRepository.GetListAsTracking(
                    x => x.WorkingDate == workingDate && x.Status == WorkingSlotRegisterStatusEnum.Approved)
                .Include(x => x.Staff)
                .Include(x => x.WorkingSlot)
                .ToListAsync();

            AssignFullTimeZones(fullTimeStaffs, diningAreas, kitchenAreas, assignedZones, zoneCapacity, staffZoneSchedules, workingDate);

            foreach (var slot in workingSlots)
            {
                AssignZones(
                    partTimeRegistrations
                        .Where(x => x.WorkingSlotId == slot.Id)
                        .Select(x => x.Staff)
                        .ToList(),
                    diningAreas,
                    kitchenAreas,
                    staffZoneSchedules,
                    assignedZones,
                    zoneCapacity,
                    workingDate,
                    slot.Id
                );
            }
        }

        _staffZoneScheduleRepository.AddRange(staffZoneSchedules);

        foreach (var schedule in staffZoneSchedules)
        {
            var workingSlotRegister = await _workingSlotRegisterRepository.GetSingleAsync(
                x => x.StaffId == schedule.StaffId &&
                     x.WorkingDate == schedule.WorkingDate &&
                     x.WorkingSlotId == schedule.WorkingSlotId);

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
        DateOnly workingDate)
    {
        int diningIndex = 0, kitchenIndex = 0;

        foreach (var staff in fullTimeStaffs)
        {
            if (staff.StaffType == StaffTypeEnum.Manager || staff.StaffType == StaffTypeEnum.ScreenChef || staff.StaffType == StaffTypeEnum.ScreenWaiter) continue;

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
        DateOnly workingDate,
        Guid workingSlotId)
    {
        foreach (var staff in staffList)
        {
            if (staff.StaffType == StaffTypeEnum.Manager) continue;

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
                    zoneName: (staff.StaffType == StaffTypeEnum.Cheff ? kitchenAreas : diningAreas)
                        .First(x => x.Id == assignedZones[staff.Id]).Name,
                    workingDate: workingDate,
                    staffId: staff.Id,
                    zoneId: assignedZones[staff.Id],
                    workingSlotId: workingSlotId));
            }
        }
    }
}