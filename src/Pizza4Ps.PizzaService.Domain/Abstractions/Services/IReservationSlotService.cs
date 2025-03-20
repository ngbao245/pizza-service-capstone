using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IReservationSlotService : IDomainService
    {
        Task<Guid> CreateAsync(TimeSpan startTime, TimeSpan endTime, int capacity);
    }
}
