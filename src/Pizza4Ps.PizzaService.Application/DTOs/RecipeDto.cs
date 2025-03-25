using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class RecipeDto
    {
        public Guid ProductSizeId { get; set; }
        public Guid? IngredientId { get; set; }
        public string IngredientName { get; set; }
        public UnitOfMeasurementType Unit { get; set; }
        public Decimal Quantity { get; set; }
    }
}
