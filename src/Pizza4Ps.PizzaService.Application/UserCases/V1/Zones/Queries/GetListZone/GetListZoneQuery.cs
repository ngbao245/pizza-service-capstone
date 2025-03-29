using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZone
{
    public class GetListZoneQuery : PaginatedQuery<PaginatedResultDto<ZoneDto>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<string>? Type { get; set; }
    }
}
