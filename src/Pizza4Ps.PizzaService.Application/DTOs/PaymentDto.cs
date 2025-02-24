using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; } = decimal.Zero;
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public Guid OrderId { get; set; }

        public virtual OrderDto Order { get; set; }
    }
}
