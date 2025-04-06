using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Config : EntityAuditBase<Guid>
    {
        public ConfigType ConfigType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string? Unit { get; set; } 
        public Config()
        {
        }

        public Config(Guid id, ConfigType configType, string key, string value, string? unit)
        {
            Id = id;
            ConfigType = configType;
            Key = key;
            Value = value;
            Unit = unit;
        }

        public void UpdateConfig(ConfigType configType, string key, string value)
        {
            ConfigType = configType;
            Key = key;
            Value = value;
        }

        public void UpdateValue(string value)
        {
            Value = value;
        }
    }
}
