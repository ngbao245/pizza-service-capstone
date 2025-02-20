using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProductIgnoreQueryFilter
{
    public class GetListProductIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<ProductDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public Guid? CategoryId { get; set; }
        public ProductTypeEnum.ProductType? ProductType { get; set; }
    }
}
