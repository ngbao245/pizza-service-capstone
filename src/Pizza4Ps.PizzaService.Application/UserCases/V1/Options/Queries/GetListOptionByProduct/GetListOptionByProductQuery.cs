using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOptionByProduct
{
    public class GetListOptionByProductQuery : PaginatedQuery<PaginatedResultDto<OptionMenuDto>>
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public decimal? AdditionalPrice { get; set; }
    }
}
