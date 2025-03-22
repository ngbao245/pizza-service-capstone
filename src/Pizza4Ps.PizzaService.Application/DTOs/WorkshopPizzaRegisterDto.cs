namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class WorkshopPizzaRegisterDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ProductId { get; set; }

        public ProductDto Product { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public List<WorkshopPizzaRegisterDetailDto> WorkshopPizzaRegisterDetails { get; set; }
    }
}
