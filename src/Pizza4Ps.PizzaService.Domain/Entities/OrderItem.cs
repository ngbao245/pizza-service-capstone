using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderItem : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string TableCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        //Bao gồm order item và order items detail
        public decimal TotalPrice { get; set; }
        public Guid OrderId { get; set; }   
        public Guid ProductId { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderItemDetail> OrderItemDetails { get; set; } = new List<OrderItemDetail>();


        public OrderItem()
        {
        }


        public OrderItem(Guid id, string name, int quantity, decimal price, Guid orderId, Guid productId, string tableCode)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            OrderId = orderId;
            ProductId = productId;
            OrderItemStatus = OrderItemStatus.Pending;
            TableCode = tableCode;
        }

        public void SetTotalPrice()
        {
            var totalOrderItemDetails = OrderItemDetails.Select(x => x.AdditionalPrice).Sum();
            var totalOrderItem = Price + totalOrderItemDetails;
            var totalPrice = totalOrderItem * Quantity;
            TotalPrice = totalPrice;
        }

        public void UpdateOrderItem(string name, int quantity, decimal price, Guid orderId, Guid productId, OrderItemStatus orderItemStatus)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            OrderId = orderId;
            ProductId = productId;
            OrderItemStatus = orderItemStatus;
        }

        public void setServing()
        {
            //if (OrderItemStatus != OrderItemStatus.Pending)
            //{
            //    throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.ORDER_ITEM_CANNOT_SERVED);
            //}
            OrderItemStatus = OrderItemStatus.Serving;
        }

        public void setDone()
        {
            OrderItemStatus = OrderItemStatus.Done;
        }

        public void setCancelled()
        {
            OrderItemStatus = OrderItemStatus.Cancelled;
        }
    }

}
