using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Day : EntityAuditBase<Guid>
    {
        public string Name { get; set; }

        public Day()
        {
        }

        public Day(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
