using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOptionIgnoreQueryFilter
{
    public class GetListProductOptionIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<ProductOptionDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public Guid? ProductId { get; set; }
        public Guid? OptionId { get; set; }
    }
}
