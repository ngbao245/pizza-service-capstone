using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ConfigDto
    {
        public Guid Id { get; set; }
        public string ConfigType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
