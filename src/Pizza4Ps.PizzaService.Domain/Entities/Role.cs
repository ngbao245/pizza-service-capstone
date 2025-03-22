using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Role : EntityAuditBase<Guid>
    {
        public string Name { get; set; }

        public Role()
        {
        }

        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
