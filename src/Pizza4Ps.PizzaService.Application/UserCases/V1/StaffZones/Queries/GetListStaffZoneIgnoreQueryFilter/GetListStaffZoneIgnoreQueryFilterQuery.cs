using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZoneIgnoreQueryFilter
{
    public class GetListStaffZoneIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<StaffZoneDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public TimeOnly? ShiftStart { get; set; }
        public TimeOnly? ShiftEnd { get; set; }
        public string? Note { get; set; }
        public Guid? StaffId { get; set; }
        public Guid? ZoneId { get; set; }
    }
}
