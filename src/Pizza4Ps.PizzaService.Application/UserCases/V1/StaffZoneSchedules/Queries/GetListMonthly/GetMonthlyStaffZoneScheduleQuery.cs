using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListMonthly
{
    public class GetMonthlyStaffZoneScheduleQuery : PaginatedQuery<PaginatedResultDto<StaffZoneScheduleDto>>
    {
        public Guid StaffId { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
    }
}