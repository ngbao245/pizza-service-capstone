using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOption
{
    public class GetListProductOptionQuery : PaginatedQuery<PaginatedResultDto<ProductOptionDto>>
    {
        public Guid? ProductId { get; set; }
        public Guid? OptionId { get; set; }
    }
}