using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTimeIgnoreQueryFilter
{
    public class GetListWorkingTimeIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<WorkingTimeDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public int? DayOfWeek { get; set; }
        public string? ShiftCode { get; set; }
        public string? Name { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
