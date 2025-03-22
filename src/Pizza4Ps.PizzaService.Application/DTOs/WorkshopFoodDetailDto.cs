namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class WorkshopFoodDetailDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid? ProductId { get; set; }

        public ProductDto Product { get; set; }
    }
}
