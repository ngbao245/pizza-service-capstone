using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions
{
    public interface IRealTimeNotifier
    {
        Task NotifyAsync(Notification notification);
        Task UpdateOrderItemStatusAsync();
        Task UpdateOrderItemCancelledStatusAsync();
        Task UpdateOrderItemDoneCookingAsync();

        Task CreatedReservationAsync(Reservation reservation);
        Task AssignReservationAsync (Reservation reservation);
        Task PaymentSuccess(Order order);
        Task UpdatedStaffZoneAsync();

    }
}
