using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Payment : EntityAuditBase<Guid>
    {
        public decimal Amount { get; set; } = decimal.Zero;
        public PaymentMethodEnum PaymentMethod { get; set; } = PaymentMethodEnum.Cash;
        public string? Status { get; set; }
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }

        public Payment()
        {
        }

        public Payment(decimal amount, PaymentMethodEnum paymentMethod, string? status, Guid orderId)
        {
            Amount = amount;
            PaymentMethod = paymentMethod;
            Status = status;
            OrderId = orderId;
        }
    }
}
