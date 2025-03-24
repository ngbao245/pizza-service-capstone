using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Ingredient : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
