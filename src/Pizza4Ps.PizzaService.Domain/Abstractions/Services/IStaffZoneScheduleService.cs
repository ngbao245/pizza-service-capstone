using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IStaffZoneScheduleService : IDomainService
    {
        Task<Guid> CreateAsync(DateOnly date, Guid staffId, Guid zoneId, Guid workingSlotIdId);
        Task AutoAssignZoneForWeekAsync(DateOnly workingDate);
        Task AutoAssignZoneForWeekJobAsync();
        Task<Guid> UpdateZoneAsync(Guid id, Guid zoneId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}

