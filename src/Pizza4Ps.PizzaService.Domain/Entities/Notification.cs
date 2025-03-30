using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Notification : EntityAuditBase<Guid>
    {
        public int Id { get; set; }
        public NotificationType Type { get; set; }
        public string Title { get; set; }       // Tiêu đề thông báo
        public string Message { get; set; }     // Nội dung thông báo
        /// <summary>
        /// Payload chứa dữ liệu bổ sung, ví dụ JSON (có thể chứa thông tin booking, id, …)
        /// </summary>
        public string Payload { get; set; }
        /// <summary>
        /// Cho biết thông báo này cần được lưu trữ để xử lý sau (persistent) hay chỉ dùng real‑time (ephemeral)
        /// </summary>
        public bool RequiresPersistence { get; set; }
        /// <summary>
        /// Trạng thái xử lý (đã xử lý/ chưa xử lý)
        /// </summary>
        public bool IsHandled { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
