using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Sizes.Commands.CreateSize
{
    public class CreateSizeCommand : IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }
        public int DiameterCm { get; set; }
        public string? Description { get; set; }
    }
}
