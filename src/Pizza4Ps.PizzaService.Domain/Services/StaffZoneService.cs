using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class StaffZoneService : DomainService, IStaffZoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffZoneRepository _staffZoneRepository;
        private readonly IStaffZoneScheduleRepository _staffZoneScheduleRepository;
        private readonly IWorkingSlotRepository _workingSlotRepository;

        public StaffZoneService(
            IUnitOfWork unitOfWork,
            IStaffZoneRepository staffZoneRepository,
            IStaffZoneScheduleRepository staffZoneScheduleRepository,
            IWorkingSlotRepository workingSlotRepository)
        {
            _unitOfWork = unitOfWork;
            _staffZoneRepository = staffZoneRepository;
            _staffZoneScheduleRepository = staffZoneScheduleRepository;
            _workingSlotRepository = workingSlotRepository;
        }

        public async Task<Guid> CreateAsync(string note, Guid staffId, Guid zoneId)
        {
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

        //public async Task SyncStaffZonesAsync(DateOnly workingDate, Guid workingSlotId)
        //{
        //    var now = TimeOnly.FromDateTime(TimeZoneInfo.ConvertTimeFromUtc(
        //        DateTime.UtcNow,
        //        TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")
        //    ));
        //    var nowSpan = now.ToTimeSpan();

        //    // Lấy ca đang xử lý
        //    var workingSlot = await _workingSlotRepository.GetSingleByIdAsync(workingSlotId);
        //    if (workingSlot == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);

        //    // Lấy tất cả schedules trong ngày
        //    var schedules = await _staffZoneScheduleRepository.GetListAsTracking(
        //        x => x.WorkingDate == workingDate).ToListAsync();

        //    var relevantSchedules = schedules.Where(x =>
        //        (x.WorkingSlotId == workingSlotId)
        //        ||
        //        (x.WorkingSlotId == null && workingSlot.ShiftStart <= nowSpan && nowSpan <= workingSlot.ShiftEnd)
        //    ).ToList();

        //    // Xóa hết staff-zone cũ
        //    var existingStaffZones = await _staffZoneRepository.GetListAsTracking().ToListAsync();
        //    foreach (var existingStaffZone in existingStaffZones)
        //    {
        //        _staffZoneRepository.SoftDelete(existingStaffZone);
        //    }

        //    // Gán lại staff-zone mới
        //    var newStaffZones = relevantSchedules
        //       .Select(s => new StaffZone(Guid.NewGuid(), null, s.StaffId, s.ZoneId))
        //       .ToList();

        //    _staffZoneRepository.AddRange(newStaffZones);
        //    await _unitOfWork.SaveChangeAsync();
        //}

        public async Task SyncStaffZonesAsync(Guid workingSlotId)
        {
            var vnNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
            var today = DateOnly.FromDateTime(vnNow);
            var nowSpan = TimeOnly.FromDateTime(vnNow).ToTimeSpan();

            // Lấy ca làm
            var workingSlot = await _workingSlotRepository.GetSingleByIdAsync(workingSlotId);
            if (workingSlot == null)
                throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);

            // Kiểm tra thời gian hiện tại có nằm trong ca không
            if (nowSpan < workingSlot.ShiftStart || nowSpan >= workingSlot.ShiftEnd)
                throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_INVALID);

            // Lấy toàn bộ schedule hôm nay, lọc ở bước sau
            var schedules = await _staffZoneScheduleRepository.GetListAsTracking(
                x => x.WorkingDate == today &&
                    (x.WorkingSlotId == workingSlotId || x.WorkingSlotId == null)
            ).ToListAsync();

            // Lọc những cái null-slot theo thời gian thực tế
            var relevantSchedules = schedules
                .Where(x => x.WorkingSlotId == workingSlotId ||
                            (x.WorkingSlotId == null && workingSlot.ShiftStart <= nowSpan && nowSpan < workingSlot.ShiftEnd))
                .ToList();

            // Xóa toàn bộ staff-zone hiện tại
            var existingStaffZones = await _staffZoneRepository.GetListAsTracking().ToListAsync();
            foreach (var zone in existingStaffZones)
            {
                _staffZoneRepository.SoftDelete(zone);
            }

            // Gán lại staff-zone mới
            var newStaffZones = relevantSchedules
                .Select(s => new StaffZone(Guid.NewGuid(), null, s.StaffId, s.ZoneId))
                .ToList();

            _staffZoneRepository.AddRange(newStaffZones);
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
            var existingStaffZone = await _staffZoneRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.ZoneId == zoneId);

            if (existingStaffZone != null)
            {
                throw new BusinessException(BussinessErrorConstants.StaffZoneErrorConstant.STAFF_ZONE_EXISTED);
            }

            var entity = await _staffZoneRepository.GetSingleByIdAsync(id);
            entity.UpdateStaffZone(note, staffId, zoneId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
