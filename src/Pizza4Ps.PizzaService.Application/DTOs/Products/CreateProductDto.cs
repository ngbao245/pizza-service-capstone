namespace Pizza4Ps.PizzaService.Application.DTOs.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
