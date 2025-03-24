using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ProductSize : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public decimal Diameter { get; set; }
        public string? Description { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

        public ProductSize(Guid id, string name, decimal diameter, string description, Guid productId)
        {
            Id = id;
            Name = name;
            Diameter = diameter;
            Description = description;
            ProductId = productId;
            Recipes = new List<Recipe>();
        }
    }
}
