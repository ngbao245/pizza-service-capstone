using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductComboItemDto
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = null!; // Món thành phần trong combo

        public int Quantity { get; set; }
    }
}
