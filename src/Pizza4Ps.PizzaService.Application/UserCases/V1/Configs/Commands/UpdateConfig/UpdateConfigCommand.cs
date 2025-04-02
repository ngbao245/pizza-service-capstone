using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Configs.Commands.UpdateConfig
{
    public class UpdateConfigCommand : IRequest<ResultDto<Guid>>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
