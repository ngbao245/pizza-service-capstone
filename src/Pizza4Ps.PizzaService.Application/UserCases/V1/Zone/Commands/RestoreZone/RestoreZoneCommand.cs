using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zone.Commands.RestoreZone
{
	public class RestoreZoneCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
