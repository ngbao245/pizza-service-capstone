using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ProductSize : EntityAuditBase<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid RecipeId { get; set; }
        public Guid SizeId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Size Size { get; set; }
        public virtual Product Products { get; set;}

        public ProductSize(Guid id ,Guid productId, Guid recipeId, Guid sizeId)
        {
            Id = id;
            ProductId = productId;
            RecipeId = recipeId;
            SizeId = sizeId;
        }
    }
}
