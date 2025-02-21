using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Order : EntityAuditBase<Guid>
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public OrderStatusEnum? Status { get; set; }
        public Guid TableId { get; set; }
        public string TableCode { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? OrderCode { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        private Order()
        {
        }

        public Order(Guid id, DateTimeOffset startTime, Guid tableId, string tableCode)
        {
            Id = id;
            StartTime = startTime;
            EndTime = null;
            Status = OrderStatusEnum.Unpaid;
            TableId = tableId;
            TableCode = tableCode;
        }

        public void SetOrderCode(string orderCode)
        {
            OrderCode = orderCode;
        }

        public void SetTotalPrice(decimal totalPrice)
        {
            TotalPrice = totalPrice;
        }

        public void SetCheckOut()
        {
            Status = OrderStatusEnum.CheckedOut;
        }
        public void SetPaid()
        {
            Status = OrderStatusEnum.Paid;
        }


        public void UpdateOrder(DateTimeOffset startTime, DateTimeOffset endTime, OrderStatusEnum status, Guid tableId)
        {
            StartTime = startTime;
            EndTime = endTime;
            Status = status;
            TableId = tableId;
        }
    }
}
