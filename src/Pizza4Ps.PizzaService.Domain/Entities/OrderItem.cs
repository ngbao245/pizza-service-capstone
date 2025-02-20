using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderItem : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

		public OrderItemTypeEnum OrderItemStatus { get; set; } = OrderItemTypeEnum.Cooking;

		public virtual Order Order { get; set; }
		public virtual Product Product { get; set; }
        public virtual ICollection<OrderItemDetail> OrderItemDetails { get; set; } = new List<OrderItemDetail>();


        public OrderItem()
		{
		}


		public OrderItem(Guid id, string name, int quantity, decimal price, Guid orderId, Guid productId, OrderItemTypeEnum orderItemStatus)
		{
			Id = id;
			Name = name;
			Quantity = quantity;
			Price = price;
			OrderId = orderId;
			ProductId = productId;
			OrderItemStatus = orderItemStatus;
		}


		public void UpdateOrderItem(string name, int quantity, decimal price, Guid orderId, Guid productId, OrderItemTypeEnum orderItemStatus)
        {
			Name = name;
			Quantity = quantity;
			Price = price;
			OrderId = orderId;
			ProductId = productId;
			OrderItemStatus = orderItemStatus;

		}
	}

}
