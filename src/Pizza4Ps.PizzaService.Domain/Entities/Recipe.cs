using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Recipe : EntityAuditBase<Guid>
    {
        public Guid? ProductId { get; set; }
        public Guid? IngredientId { get; set; }
        public string IngredientName { get; set; }
        public UnitOfMeasurementType Unit {  get; set; }
        public decimal Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        public Recipe(Guid id, Guid? ingredientId, string ingredientName, 
            UnitOfMeasurementType unit, decimal quantity, Guid productId)
        {
            Id = id;
            IngredientId = ingredientId;
            IngredientName = ingredientName;
            Unit = unit;
            Quantity = quantity;
            ProductId = productId;
        }
        public Recipe()
        {
            
        }
    }
}
