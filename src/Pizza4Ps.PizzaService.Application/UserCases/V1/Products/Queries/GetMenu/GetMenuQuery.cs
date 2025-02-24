using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetMenu
{
    public class GetMenuQuery : PaginatedQuery<PaginatedResultDto<ProductMenuDto>>
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public Guid? CategoryId { get; set; }
        public ProductTypeEnum? ProductType { get; set; }
    }
}