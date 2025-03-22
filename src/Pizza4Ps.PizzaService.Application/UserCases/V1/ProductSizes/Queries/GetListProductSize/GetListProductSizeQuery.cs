using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetListProductSize
{
    public class GetListProductSizeQuery : PaginatedQuery<PaginatedResultDto<ProductSizeDto>>
    {
        public Guid? ProductId { get; set; }
        public Guid? RecipeId { get; set; }
        public Guid? SizeId { get; set; }

    }
}
