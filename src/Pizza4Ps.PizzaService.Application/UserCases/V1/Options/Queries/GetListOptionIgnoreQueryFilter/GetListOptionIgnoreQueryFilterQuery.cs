using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOptionIgnoreQueryFilter
{
    public class GetListOptionIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<OptionDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
