using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions
{
    public interface IRealTimeNotifier
    {
        Task NotifyAsync(Notification notification);
        Task UpdateOrderItemStatusAsync();
        Task CreatedReservationAsync(Reservation reservation);
        Task AssignReservationAsync (Reservation reservation);
        Task UpdatedStaffZoneAsync();

    }
}
