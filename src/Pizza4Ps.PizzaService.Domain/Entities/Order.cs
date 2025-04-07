using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Order : EntityAuditBase<Guid>
    {
        public string? OrderCode { get; set; }
        public string TableCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? TotalOrderItemPrice { get; set; }
        public decimal? TotalAdditionalFeePrice { get; set; }
        public OrderStatusEnum Status { get; set; }
        public OrderTypeEnum Type { get; set; }
        public string? Phone { get; set; }

        public Guid TableId { get; set; }

        public virtual Table Table { get; set; }
        public virtual ICollection<AdditionalFee> AdditionalFees { get; set; } = new List<AdditionalFee>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        private Order()
        {
        }

        public Order(Guid id, Guid tableId, string tableCode, OrderTypeEnum type)
        {
            Id = id;
            OrderCode = null;
            TableCode = tableCode;
            StartTime = DateTime.Now;
            EndTime = null;
            TotalPrice = null;
            Status = OrderStatusEnum.Unpaid;
            Type = type;
            TableId = tableId;
        }

        public void SetOrderCode(string orderCode)
        {
            OrderCode = orderCode;
        }

        public void SetTotalPrice(decimal totalPrice)
        {
            TotalPrice = totalPrice;
        }
        public void SetTotalOrderItemPrice(decimal totalOrderItemPrice)
        {
            TotalOrderItemPrice = totalOrderItemPrice;
        }
        public void SetTotalAdditionalFeePrice(decimal totalAdditionalFeePrice)
        {
            TotalAdditionalFeePrice = totalAdditionalFeePrice;
        }

        public void SetCancelCheckOut()
        {
            Status = OrderStatusEnum.Unpaid;
        }

        public void SetCheckOut()
        {
            Status = OrderStatusEnum.CheckedOut;
        }

        public void SetPaid()
        {
            Status = OrderStatusEnum.Paid;
        }


        public void UpdateOrder(DateTime startTime, DateTime endTime, OrderStatusEnum status, Guid tableId)
        {
            StartTime = startTime;
            EndTime = endTime;
            Status = status;
            TableId = tableId;
        }
    }
}
