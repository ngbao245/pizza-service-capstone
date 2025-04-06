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

        public StaffZoneService(IUnitOfWork unitOfWork, IStaffZoneRepository staffZoneRepository, IStaffZoneScheduleRepository staffZoneScheduleRepository)
        {
            _unitOfWork = unitOfWork;
            _staffZoneRepository = staffZoneRepository;
            _staffZoneScheduleRepository = staffZoneScheduleRepository;
        }

        public async Task<Guid> CreateAsync(string note, Guid staffId, Guid zoneId)
        {
            var existingStaffZone = await _staffZoneRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.ZoneId == zoneId);

            if (existingStaffZone != null)
            {
                throw new BusinessException(BussinessErrorConstants.StaffZoneErrorConstant.STAFF_NOT_FOUND);
            }

            var staffZone = new StaffZone(Guid.NewGuid(), note, staffId, zoneId);
            _staffZoneRepository.Add(staffZone);
            await _unitOfWork.SaveChangeAsync();
            return staffZone.Id;
        }

        public async Task SyncStaffZonesAsync(DateOnly workingDate, Guid workingSlotId)
        {
            var schedules = await _staffZoneScheduleRepository.GetListAsTracking(
                x => x.WorkingDate == workingDate
                && x.WorkingSlotId == workingSlotId)
                .ToListAsync();

            var newStaffZones = new List<StaffZone>();

            foreach (var schedule in schedules)
            {
                var existingStaffZone = await _staffZoneRepository.GetSingleAsync(
                    x => x.StaffId == schedule.StaffId
                    && x.ZoneId == schedule.ZoneId);

                if (existingStaffZone == null)
                {
                    newStaffZones.Add(new StaffZone(Guid.NewGuid(), null, schedule.StaffId, schedule.ZoneId));
                }
            }

            if (newStaffZones.Any())
            {
                _staffZoneRepository.AddRange(newStaffZones);
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
            var entity = await _staffZoneRepository.GetSingleByIdAsync(id);
            entity.UpdateStaffZone(note, staffId, zoneId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
