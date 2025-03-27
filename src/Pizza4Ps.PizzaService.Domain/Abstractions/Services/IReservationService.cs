using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IReservationService : IDomainService
    {
        Task<Guid> CreateAsync(string customerName, string phoneNumber, DateTime bookingTime, int numberOfPeople);
        Task<Guid> UpdateAsync(Guid id, DateTime bookingDate, int guestCount, string status, Guid customerId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
        Task<bool> AssignTableAsync(Guid reservationId, Guid tableId);
        Task<bool> CheckInAsync(Guid reservationId);
    }
}
