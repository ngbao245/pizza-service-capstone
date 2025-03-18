using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Zone : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ZoneTypeEnum Status { get; set; }

        private Zone()
        {
        }

        public Zone(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = ZoneTypeEnum.Available;
        }

        public void UpdateZone(string name, string description, ZoneTypeEnum status)
        {
            Name = name;
            Description = description;
            Status = status;
        }
    }
}
