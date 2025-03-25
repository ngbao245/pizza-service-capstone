using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Recipe : EntityAuditBase<Guid>
    {
        public Guid ProductSizeId { get; set; }
        public Guid? IngredientId { get; set; }
        public string IngredientName { get; set; }
        public UnitOfMeasurementType Unit {  get; set; }
        public decimal Quantity { get; set; }


        public virtual Ingredient Ingredient { get; set; }
        public virtual ProductSize ProductSize { get; set; }

        public Recipe(Guid id, Guid productSizeId, Guid? ingredientId, string ingredientName, UnitOfMeasurementType unit, decimal quantity)
        {
            Id = id;
            ProductSizeId = productSizeId;
            IngredientId = ingredientId;
            IngredientName = ingredientName;
            Unit = unit;
            Quantity = quantity;
        }
    }
}
