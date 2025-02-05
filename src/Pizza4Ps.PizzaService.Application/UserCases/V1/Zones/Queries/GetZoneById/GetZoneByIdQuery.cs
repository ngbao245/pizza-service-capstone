using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetZoneById
{
    public class GetZoneByIdQuery : IRequest<ZoneDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
