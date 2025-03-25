using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetListProductSize
{
    public class GetListProductSizeQuery : PaginatedQuery<PaginatedResultDto<ProductSizeDto>>
    {
        public string? Name { get; set; }
        public decimal? Diameter { get; set; }
        public string? Description { get; set; }
        public Guid? ProductId { get; set; }

    }
}
