using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class Payment : EntityAuditBase<Guid>
	{
		public decimal Amount { get; set; }
		public PaymentMethodEnum PaymentMethod { get; set; }
		public DateTimeOffset? PaidTime { get; set; }
        public Guid OrderId { get; set; }
		public string OrderCode { get; set; }
        public virtual Order Order { get; set; }

		public Payment()
		{
		}

		public Payment(Guid id, decimal amount, PaymentMethodEnum paymentMethod, Guid orderId, string orderCode)
		{
			Id = id;
			Amount = amount;
			PaymentMethod = paymentMethod;
			OrderId = orderId;
            OrderCode = orderCode;
        }
	}
}
