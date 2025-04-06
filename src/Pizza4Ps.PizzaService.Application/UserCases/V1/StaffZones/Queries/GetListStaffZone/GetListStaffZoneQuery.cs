using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZone
{
    public class GetListStaffZoneQuery : PaginatedQuery<PaginatedResultDto<StaffZoneDto>>
    {
        public Guid? StaffId { get; set; }
        public Guid? ZoneId { get; set; }
    }
}
