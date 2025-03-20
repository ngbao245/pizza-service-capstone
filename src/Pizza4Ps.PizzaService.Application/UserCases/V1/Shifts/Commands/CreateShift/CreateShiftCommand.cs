using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Shifts.Commands.CreateShift
{
    public class CreateShiftCommand : IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
