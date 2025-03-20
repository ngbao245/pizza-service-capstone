using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Shift : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public Shift()
        {
        }

        public Shift(Guid id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
