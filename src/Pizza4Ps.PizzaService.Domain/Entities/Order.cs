using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Order : EntityAuditBase<Guid>
    {
        public string? Status { get; set; }
        public Guid OrderInTableId { get; set; }

        public virtual OrderInTable OrderInTable { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<OrderVoucher> OrderVouchers { get; set; }

        private Order()
        {
        }

        public Order(string? status, Guid orderInTableId)
        {
            Status = status;
            OrderInTableId = orderInTableId;
        }
    }
}
