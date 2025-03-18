using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Config : EntityAuditBase<Guid>
    {
        public ConfigType ConfigType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
