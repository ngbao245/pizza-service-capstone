using Microsoft.AspNetCore.SignalR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Infrastructure.Services
{
    public class RealTimeNotifier : IRealTimeNotifier
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public RealTimeNotifier(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task AssignReservationAsync(Reservation reservation)
        {
            await _hubContext.Clients.All.SendAsync("AssignTableForReservation", reservation);
        }

        public async Task CreatedReservationAsync(Reservation reservation)
        {
            await _hubContext.Clients.All.SendAsync("ReservationCreated", reservation);
        }

        public async Task NotifyAsync(Notification notification)
        {
            // Ví dụ: với CallStaff, gửi đến group của khu vực và đồng thời gửi đến ManagersGroup
            if (notification.Type == NotificationType.CallStaff)
            {
                await _hubContext.Clients.Groups(new[] { $"Zone_{notification.Payload}", "ManagersGroup" })
                    .SendAsync("ReceiveNotification", new
                    {
                        notification.Id,
                        notification.Type,
                        notification.Title,
                        notification.Message,
                        notification.Payload,
                        notification.CreatedAt
                    });
            }
            else
            {
                // Xử lý các loại thông báo khác (ví dụ Booking, v.v.)
                await _hubContext.Clients.Group("DefaultGroup")
                    .SendAsync("ReceiveNotification", new
                    {
                        notification.Id,
                        notification.Type,
                        notification.Title,
                        notification.Message,
                        notification.Payload,
                        notification.CreatedAt
                    });
            }
        }

        public async Task PaymentSuccess(Order order)
        {
            await _hubContext.Clients.All.SendAsync("PaymentSuccess", order);
        }

        public async Task UpdatedStaffZoneAsync()
        {
            // Gửi đến tất cả client đang kết nối
            await _hubContext.Clients.All.SendAsync("UpdatedStaffZoneAsync");
        }

        public async Task UpdateOrderItemDoneCookingAsync()
        {
            // Gửi đến tất cả client đang kết nối
            await _hubContext.Clients.All.SendAsync("OrderItemDoneCooking");
        }

        public async Task UpdateOrderItemStatusAsync()
        {
            // Gửi đến tất cả client đang kết nối
            await _hubContext.Clients.All.SendAsync("OrderItemUpdatedStatus");
        }
    }
}
