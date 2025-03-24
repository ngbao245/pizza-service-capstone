using Pizza4Ps.PizzaService.Domain.Entities;
using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OrderItemDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }
        public Guid OrderItemId { get; set; }
        //[JsonIgnore]
        //public virtual OrderItemDto OrderItem { get; set; }
    }
}
