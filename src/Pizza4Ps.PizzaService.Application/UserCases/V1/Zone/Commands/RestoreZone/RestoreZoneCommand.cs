using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zone.Commands.RestoreZone
{
	public class RestoreZoneCommand : BaseRestoreCommand<Guid>, IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
