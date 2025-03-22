using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetListProductSize
{
    public class GetListProductSizeQuery : PaginatedQuery<PaginatedResultDto<ProductSizeDto>>
    {
        public string? ProductId { get; set; }
        public string? RecipeId { get; set; }
        public string? SizeId { get; set; }

    }
}
