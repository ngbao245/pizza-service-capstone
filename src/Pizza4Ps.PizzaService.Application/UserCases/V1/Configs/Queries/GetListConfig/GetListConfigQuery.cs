using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Configs.Queries.GetListConfig
{
    public class GetListConfigQuery : PaginatedQuery<PaginatedResultDto<ConfigDto>>
    {
        public string? ConfigType { get; set; }
        public string? Key { get; set; }
    }
}