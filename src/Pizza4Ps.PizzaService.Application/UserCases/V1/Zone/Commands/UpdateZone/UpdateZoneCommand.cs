using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zone.Commands.UpdateZone
{
	public class UpdateZoneCommand : BaseUpdateCommand<Guid>, IRequest<UpdateZoneCommandResponse>
	{
		public string Name { get; set; }
		public int? Capacity { get; set; }
		public string? Description { get; set; }
		public ZoneTypeEnum Status { get; set; } = ZoneTypeEnum.Available;
	}
}
