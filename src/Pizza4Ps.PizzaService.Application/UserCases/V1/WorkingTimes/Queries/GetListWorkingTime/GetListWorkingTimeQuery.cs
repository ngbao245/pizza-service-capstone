using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTime
{
    public class GetListWorkingTimeQuery : PaginatedQuery<PaginatedResultDto<WorkingTimeDto>>
    {
        public int? DayOfWeek { get; set; }
        public string? ShiftCode { get; set; }
        public string? Name { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}