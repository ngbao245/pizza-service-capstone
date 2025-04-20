using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.CreateOptionItem;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.CreateOption
{
    public class CreateOptionCommand : IRequest<ResultDto<Guid>>
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool SelectMany { get; set; }
        public List<CreateOptionItemCommand> OptionItems { get; set; }
    }
}
