using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ReasonConfigs.Commands.CreateReasonConfig
{
    public class CreateReasonConfigCommand : IRequest<ResultDto<Guid>>
    {
        public string Reason { get; set; }
        public string ReasonType { get; set; }
    }
}