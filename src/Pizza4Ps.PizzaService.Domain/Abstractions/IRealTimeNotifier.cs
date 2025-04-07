using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions
{
    public interface IRealTimeNotifier
    {
        Task NotifyAsync(Notification notification);
        Task UpdateOrderItemStatusAsync();
    }
}
