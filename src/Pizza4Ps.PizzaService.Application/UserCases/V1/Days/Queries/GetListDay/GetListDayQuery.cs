using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Days.Queries.GetListDay
{
    public class GetListDayQuery : PaginatedQuery<PaginatedResultDto<DayDto>>
    {
        public string? Name { get; set; }

    }
}
