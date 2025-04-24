using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IReservationService : IDomainService
    {
        Task<Guid> CreateAsync(string customerName, string phoneNumber, string phoneOtp, DateTime bookingTime, int numberOfPeople);
        Task ChangeBookingTimeAsync(Guid id, DateTime bookingTime, int numberOfPeople);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
        Task<bool> AssignTableAsync(Guid reservationId, List<Guid> tableIds);
        Task<bool> UnAssignTableAsync(Guid reservationId, List<Guid> tableIds);
        Task CheckInAsync(Guid reservationId);
        Task ConfirmAsync(Guid reservationId);
        Task CancelAsync(Guid reservationId);
    }
}
