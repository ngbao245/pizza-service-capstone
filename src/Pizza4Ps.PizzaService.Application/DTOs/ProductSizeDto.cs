namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductSizeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Diameter { get; set; }
        public string? Description { get; set; }
        public Guid ProductId { get; set; }
        public virtual ICollection<RecipeDto> Recipes { get; set; } = new List<RecipeDto>();
    }
}
