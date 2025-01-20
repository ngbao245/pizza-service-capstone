using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneScheduleIgnoreQueryFilter
{
    public class GetListStaffZoneScheduleIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<StaffZoneScheduleDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public int? DayofWeek { get; set; }
        public TimeOnly? ShiftStart { get; set; }
        public TimeOnly? ShiftEnd { get; set; }
        public string? Note { get; set; }
        public Guid? StaffId { get; set; }
        public Guid? ZoneId { get; set; }
        public Guid? WorkingTimeId { get; set; }
    }
}
