using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid? IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string Unit { get; set; }
        public Decimal Quantity { get; set; }
        public virtual IngredientDto Ingredient { get; set; }
    }
}
