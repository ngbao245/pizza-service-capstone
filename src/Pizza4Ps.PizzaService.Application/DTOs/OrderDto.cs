using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string TableCode { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? OrderCode { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public OrderStatusEnum Status { get; set; }
        public Guid TableId { get; set; }

        public virtual TableDto Table { get; set; }
    }
}
