using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ReasonConfigs.Queries.GetReasonConfigList
{
    public class GetReasonConfigListQuery : PaginatedQuery<PaginatedResultDto<ReasonConfigDto>>
    {
        public string? SearchTerm { get; set; }
        public string? ReasonConfigType { get; set; } 
    }
}
