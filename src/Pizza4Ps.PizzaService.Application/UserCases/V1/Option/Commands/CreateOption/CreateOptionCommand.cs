using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Commands.CreateOption
{
	public class CreateOptionCommand : IRequest<CreateOptionCommandResponse>
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
