using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class Order : EntityAuditBase<Guid>
	{
		public DateTimeOffset StartTime { get; set; }
		public DateTimeOffset EndTime { get; set; }
		public string? Status { get; set; }
		public Guid OrderInTableId { get; set; }

		public virtual OrderInTable OrderInTable { get; set; }
		public virtual ICollection<OrderItem> OrderItems { get; set; }
		public virtual ICollection<Feedback> Feedbacks { get; set; }
		public virtual ICollection<Payment> Payments { get; set; }
		public virtual ICollection<OrderVoucher> OrderVouchers { get; set; }

		private Order()
		{
		}

		public Order(DateTimeOffset startTime, DateTimeOffset endTime, string? status, Guid orderInTableId)
		{
			StartTime = startTime;
			EndTime = endTime;
			Status = status;
			OrderInTableId = orderInTableId;
		}

		public void UpdateOrder(DateTimeOffset startTime, DateTimeOffset endTime, string? status, Guid orderInTableId)
		{
			StartTime = startTime;
			EndTime = endTime;
			Status = status;
			OrderInTableId = orderInTableId;
		}
	}
}
