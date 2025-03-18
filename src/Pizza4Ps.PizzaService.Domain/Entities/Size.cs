using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Size : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public int DiameterCm { get; set; }
        public string? Description { get; set; }

        public Size()
        {
        }

        public Size(Guid id, string name, int diameterCm, string description)
        {
            Id = id;
            Name = name;
            DiameterCm = diameterCm;
            Description = description;
        }
    }
}
