namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public virtual CategoryDto Category { get; set; }
    }
}
