using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Commands.DeleteOption
{
	public class DeleteOptionCommand : BaseDeleteCommand, IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
