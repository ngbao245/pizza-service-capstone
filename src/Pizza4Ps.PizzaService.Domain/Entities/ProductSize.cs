using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ProductSize : EntityAuditBase<Guid>
    {
        public string ProductId { get; set; }
        public string RecipeId { get; set; }
        public string SizeId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<Product> Products { get; set;}

        public ProductSize(string productId, string recipeId, string sizeId, Recipe recipe, Size size)
        {
            ProductId = productId;
            RecipeId = recipeId;
            SizeId = sizeId;
            Recipe = recipe;
            Size = size;
        }
    }
}
