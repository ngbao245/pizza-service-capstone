using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }
        public Guid? OrderItemDetailId { get; set; }
        public virtual OrderDto Order { get; set; }
        public virtual ProductDto Product { get; set; }
        public virtual ICollection<OrderItemDetailDto> ProductDetails { get; set; }
    }
}
