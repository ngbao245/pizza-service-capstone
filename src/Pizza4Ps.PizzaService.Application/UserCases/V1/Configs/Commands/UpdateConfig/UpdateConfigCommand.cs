using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Configs.Commands.UpdateConfig
{
    public class UpdateConfigCommand : IRequest
    {
        public Guid? Id { get; set; }
        public ConfigType ConfigType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
