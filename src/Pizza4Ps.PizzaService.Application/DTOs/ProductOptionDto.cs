using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductOptionDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OptionId { get; set; }

        [JsonIgnore]
        public virtual ProductDto Product { get; set; }
        public virtual OptionDto Option { get; set; }
    }
}
