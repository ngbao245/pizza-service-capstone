using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategory
{
    public class GetListCategoryQuery : PaginatedQuery<PaginatedResultDto<CategoryDto>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}

