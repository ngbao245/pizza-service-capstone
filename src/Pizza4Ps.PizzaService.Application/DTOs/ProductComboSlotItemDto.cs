namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductComboSlotItemDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public virtual ProductDto Product { get; set; } = null!; // Món thành phần trong combo
    }
}
