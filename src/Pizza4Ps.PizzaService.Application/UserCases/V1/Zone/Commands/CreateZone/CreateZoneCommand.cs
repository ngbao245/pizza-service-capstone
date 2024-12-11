using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zone.Commands.CreateZone
{
	public class CreateZoneCommand : IRequest<CreateZoneCommandResponse>
	{
		public string Name { get; set; }
		public int? Capacity { get; set; }
		public string? Description { get; set; }
		public ZoneTypeEnum Status { get; set; } = ZoneTypeEnum.Available;
	}
}
