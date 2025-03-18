using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Recipe : EntityAuditBase<Guid>
    {
        public string Unit { get; set; }

        public Guid ProductId { get; set; }
        public Guid IngredientId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        public Recipe(Guid id, string unit, Guid productId, Guid ingredientId)
        {
            Id = id;
            Unit = unit;
            ProductId = productId;
            IngredientId = ingredientId;
        }
    }
}
