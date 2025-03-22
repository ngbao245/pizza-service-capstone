using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Recipe : EntityAuditBase<Guid>
    {
        public string Unit { get; set; }
        public string Name { get; set; }

        public Recipe(Guid id, string unit, string name)
        {
            Id = id;
            Unit = unit;
            Name = name;
        }
    }
}
