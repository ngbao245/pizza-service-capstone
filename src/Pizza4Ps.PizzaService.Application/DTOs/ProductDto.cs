using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductType { get; set; }

        public virtual CategoryDto Category { get; set; }
        public virtual ICollection<ProductOptionDto> ProductOptions { get; set; } = new List<ProductOptionDto>();
    }
}
