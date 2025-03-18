using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Ingredients.Queries.GetListIngredient
{
    public class GetListIngredientQuery : PaginatedQuery<PaginatedResultDto<IngredientDto>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}

