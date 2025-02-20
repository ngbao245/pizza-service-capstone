using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OrderItemDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }
        public Guid OptionItemId { get; set; }
        public Guid OrderItemId { get; set; }

        public virtual OptionItemDto OptionItem { get; set; }
        [JsonIgnore]
        public virtual OrderItemDto OrderItem { get; set; }
    }
}
