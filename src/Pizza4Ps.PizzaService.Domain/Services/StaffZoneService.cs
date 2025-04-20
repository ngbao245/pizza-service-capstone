using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class StaffZoneService : DomainService, IStaffZoneService
    {
        private readonly IRealTimeNotifier _realTimeNotifier;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffZoneRepository _staffZoneRepository;
        private readonly IStaffZoneScheduleRepository _staffZoneScheduleRepository;
        private readonly IWorkingSlotRepository _workingSlotRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IZoneRepository _zoneRepository;
        private readonly IStaffAbsenceRepository _staffAbsenceRepository;

        public StaffZoneService(
            IUnitOfWork unitOfWork,
            IStaffZoneRepository staffZoneRepository,
            IStaffZoneScheduleRepository staffZoneScheduleRepository,
            IWorkingSlotRepository workingSlotRepository,
            IStaffRepository staffRepository,
            IZoneRepository zoneRepository,
            IRealTimeNotifier realTimeNotifier,
            IStaffAbsenceRepository staffAbsenceRepository)
        {
            _realTimeNotifier = realTimeNotifier;
            _unitOfWork = unitOfWork;
            _staffZoneRepository = staffZoneRepository;
            _staffZoneScheduleRepository = staffZoneScheduleRepository;
            _workingSlotRepository = workingSlotRepository;
            _staffRepository = staffRepository;
            _zoneRepository = zoneRepository;
            _staffAbsenceRepository = staffAbsenceRepository;
        }

        public async Task<Guid> CreateAsync(string note, Guid staffId, Guid zoneId)
        {
            await ValidateStaffZoneAssignment(staffId, zoneId);

            var existingStaffZone = await _staffZoneRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.ZoneId == zoneId);

            if (existingStaffZone != null)
            {
                throw new BusinessException(BussinessErrorConstants.StaffZoneErrorConstant.STAFF_ZONE_EXISTED);
            }

            var staffZone = new StaffZone(Guid.NewGuid(), note, staffId, zoneId);
            _staffZoneRepository.Add(staffZone);
            await _unitOfWork.SaveChangeAsync();
            return staffZone.Id;
        }

        //public async Task SyncStaffZonesAsync(Guid workingSlotId)
        //{
        //    var vnNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        //    var today = DateOnly.FromDateTime(vnNow);
        //    var nowSpan = TimeOnly.FromDateTime(vnNow).ToTimeSpan();

        //    var workingSlot = await _workingSlotRepository.GetSingleByIdAsync(workingSlotId);
        //    if (workingSlot == null)
        //        throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);

        //    // Kiểm tra thời gian hiện tại có nằm trong ca không
        //    if (nowSpan < workingSlot.ShiftStart || nowSpan >= workingSlot.ShiftEnd)
        //        throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_INVALID);

        //    // Lấy toàn bộ schedule hôm nay, lọc ở bước sau
        //    var schedules = await _staffZoneScheduleRepository.GetListAsTracking(
        //        x => x.WorkingDate == today &&
        //            (x.WorkingSlotId == workingSlotId || x.WorkingSlotId == null)
        //    ).ToListAsync();

        //    var absences = await _staffAbsenceRepository.GetListAsTracking(
        //        x => x.AbsentDate == today && x.WorkingSlotId == workingSlotId).ToListAsync();
        //    var absentStaffIds = absences.Select(x => x.StaffId).ToHashSet();

        //    // Lọc những cái null-slot theo thời gian thực tế
        //    var relevantSchedules = schedules
        //        .Where(x => !absentStaffIds.Contains(x.StaffId))
        //        .Where(x => x.WorkingSlotId == workingSlotId ||
        //                    (x.WorkingSlotId == null && workingSlot.ShiftStart <= nowSpan && nowSpan < workingSlot.ShiftEnd))
        //        .ToList();

        //    var existingStaffZones = await _staffZoneRepository.GetListAsTracking().ToListAsync();

        //    // Xóa các StaffZone nếu nhân viên đã được đánh dấu vắng mặt trong ca
        //    var staffZonesToRemove = existingStaffZones.Where(z => absentStaffIds.Contains(z.StaffId)).ToList();

        //    foreach (var staffZone in staffZonesToRemove)
        //    {
        //        _staffZoneRepository.SoftDelete(staffZone);
        //    }

        //    foreach (var schedule in relevantSchedules)
        //    {
        //        var hasSameZone = existingStaffZones.Any(z => z.StaffId == schedule.StaffId && z.ZoneId == schedule.ZoneId);
        //        var hasDifferentZone = existingStaffZones.Any(z => z.StaffId == schedule.StaffId && z.ZoneId != schedule.ZoneId);

        //        if (!hasSameZone && !hasDifferentZone)
        //        {
        //            var staffZone = new StaffZone(Guid.NewGuid(), null, schedule.StaffId, schedule.ZoneId);
        //            _staffZoneRepository.Add(staffZone);
        //        }
        //    }
        //    await _unitOfWork.SaveChangeAsync();
        //}

        public async Task SyncStaffZonesAsync(Guid workingSlotId)
        {
            var vnNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
            var today = DateOnly.FromDateTime(vnNow);
            var nowSpan = TimeOnly.FromDateTime(vnNow).ToTimeSpan();

            var workingSlot = await _workingSlotRepository.GetSingleByIdAsync(workingSlotId);
            if (workingSlot == null)
                throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);

            // Không chặn nếu không trong ca - chỉ sync những người hợp lệ

            var schedules = await _staffZoneScheduleRepository.GetListAsTracking(
                x => x.WorkingDate == today &&
                    (x.WorkingSlotId == workingSlotId || x.WorkingSlotId == null)
            ).ToListAsync();

            var absences = await _staffAbsenceRepository.GetListAsTracking(
                x => x.AbsentDate == today && x.WorkingSlotId == workingSlotId
            ).ToListAsync();
            var absentStaffIds = absences.Select(x => x.StaffId).ToHashSet();

            // Lọc ra lịch hợp lệ: không vắng mặt + đúng ca hoặc nằm trong thời gian ca
            var relevantSchedules = schedules
                .Where(x => !absentStaffIds.Contains(x.StaffId))
                .Where(x =>
                    x.WorkingSlotId == workingSlotId || // part-time đúng ca
                    (x.WorkingSlotId == null && // full-time và đang trong giờ ca
                     workingSlot.ShiftStart <= nowSpan && nowSpan < workingSlot.ShiftEnd))
                .ToList();

            var relevantStaffIds = relevantSchedules.Select(x => x.StaffId).ToHashSet();

            var existingStaffZones = await _staffZoneRepository.GetListAsTracking().ToListAsync();

            // Xóa những StaffZone không hợp lệ nữa
            var staffZonesToRemove = existingStaffZones
                .Where(z => !relevantStaffIds.Contains(z.StaffId))
                .ToList();

            foreach (var staffZone in staffZonesToRemove)
            {
                _staffZoneRepository.SoftDelete(staffZone);
            }

            // Thêm mới nếu chưa có
            foreach (var schedule in relevantSchedules)
            {
                var hasSameZone = existingStaffZones.Any(z =>
                    z.StaffId == schedule.StaffId && z.ZoneId == schedule.ZoneId && !z.IsDeleted);
                var hasDifferentZone = existingStaffZones.Any(z =>
                    z.StaffId == schedule.StaffId && z.ZoneId != schedule.ZoneId && !z.IsDeleted);

                if (!hasSameZone && !hasDifferentZone)
                {
                    var staffZone = new StaffZone(Guid.NewGuid(), null, schedule.StaffId, schedule.ZoneId);
                    _staffZoneRepository.Add(staffZone);
                }
            }

            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _staffZoneRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _staffZoneRepository.HardDelete(entity);
                }
                else
                {
                    _staffZoneRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _staffZoneRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _staffZoneRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string note, Guid staffId, Guid zoneId)
        {
            await ValidateStaffZoneAssignment(staffId, zoneId);

            var existingStaffZone = await _staffZoneRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.ZoneId == zoneId && x.Id != id);

            if (existingStaffZone != null)
            {
                throw new BusinessException(BussinessErrorConstants.StaffZoneErrorConstant.STAFF_ZONE_EXISTED);
            }

            var entity = await _staffZoneRepository.GetSingleByIdAsync(id);
            entity.UpdateStaffZone(note, staffId, zoneId);
            await _unitOfWork.SaveChangeAsync();
            await _realTimeNotifier.UpdatedStaffZoneAsync();
            return entity.Id;
        }

        private async Task ValidateStaffZoneAssignment(Guid staffId, Guid zoneId)
        {
            var staff = await _staffRepository.GetSingleByIdAsync(staffId)
                ?? throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);

            var zone = await _zoneRepository.GetSingleByIdAsync(zoneId)
                ?? throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);

            switch (zone.Type)
            {
                case ZoneTypeEnum.KitchenArea:
                    if (staff.StaffType != StaffTypeEnum.Cheff)
                        throw new BusinessException(BussinessErrorConstants.StaffZoneErrorConstant.STAFF_ZONE_INVALID_CHEF);
                    break;

                case ZoneTypeEnum.DininingArea:
                    if (staff.StaffType == StaffTypeEnum.Cheff)
                        throw new BusinessException(BussinessErrorConstants.StaffZoneErrorConstant.STAFF_ZONE_INVALID_STAFF);
                    break;
                case ZoneTypeEnum.WorkshopArea:
                    break;
            }
        }
    }
}
