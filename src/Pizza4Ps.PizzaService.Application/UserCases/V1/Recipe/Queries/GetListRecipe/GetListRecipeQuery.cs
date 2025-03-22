using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Queries.GetListRecipe
{
    public class GetListRecipeQuery: PaginatedQuery<PaginatedResultDto<RecipeDto>>
    {
        public string? Unit { get; set; }
        public string? Name { get; set; }
    }
}
