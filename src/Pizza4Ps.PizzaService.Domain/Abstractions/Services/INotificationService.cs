using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface INotificationService : IDomainService
    {
        Task SendStaffCallNotificationAsync(string table, string zone, string? note);
        Task SendBookingNotificationAsync(string bookingId, string bookingMessage);
    }
}
