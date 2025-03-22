using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IWorkingSlotService : IDomainService
    {
        Task<Guid> CreateAsync(TimeSpan shiftStart, TimeSpan shiftEnd, int capacity, Guid dayId, Guid shiftId);
    }
}
