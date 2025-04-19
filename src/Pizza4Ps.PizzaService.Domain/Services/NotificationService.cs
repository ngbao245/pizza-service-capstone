using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class NotificationService : DomainService, INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRealTimeNotifier _notifier;
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(IRealTimeNotifier notifier,
                                   INotificationRepository notificationRepository,
                                   IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notifier = notifier;
            _notificationRepository = notificationRepository;
        }

        /// <summary>
        /// Use Case: Staff Call
        /// Gửi notification gọi nhân viên tới khu vực cụ thể và lưu vào bảng notification để hiển thị nút chuông.
        /// </summary>
        /// <param name="zone">Tên khu vực (ví dụ: "Zone_A")</param>
        public async Task SendStaffCallNotificationAsync(string table, string zone, string? note)
        {
            var notification = new Notification
            {
                Type = NotificationType.CallStaff,
                Title = "Gọi nhân viên",
                Message = note == null ? $"Có yêu cầu gọi nhân viên tại bàn {table} - khu vực {zone}" : note,
                Payload = zone, // Payload chứa tên zone
                RequiresPersistence = true, // Lưu thông báo để hiển thị trên nút chuông
                IsHandled = false,
                CreatedAt = DateTime.Now
            };

            // Gửi thông báo real‑time qua SignalR
            await _notifier.NotifyAsync(notification);
        }

        /// <summary>
        /// Use Case: Booking (ví dụ)
        /// Gửi và lưu thông báo booking.
        /// </summary>
        public async Task SendBookingNotificationAsync(string bookingId, string bookingMessage)
        {
            var notification = new Notification
            {
                Type = NotificationType.Booking,
                Title = "Thông báo Booking",
                Message = bookingMessage,
                Payload = bookingId,
                RequiresPersistence = true,
                IsHandled = false,
                CreatedAt = DateTime.Now
            };

            await _notifier.NotifyAsync(notification);
            _notificationRepository.Add(notification);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
