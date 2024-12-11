using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Commands.RestoreOption
{
	public class RestoreOptionCommand : BaseRestoreCommand<Guid>, IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
