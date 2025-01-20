using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOption
{
    public class GetListOptionQuery : PaginatedQuery<PaginatedResultDto<OptionDto>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
