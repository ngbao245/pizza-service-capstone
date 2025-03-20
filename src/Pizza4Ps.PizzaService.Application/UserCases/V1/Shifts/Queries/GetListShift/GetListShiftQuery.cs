using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Shifts.Queries.GetListShift
{
    public class GetListShiftQuery : PaginatedQuery<PaginatedResultDto<ShiftDto>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
