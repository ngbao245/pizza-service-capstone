using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Queries.GetListRecipe
{
    public class GetListRecipeQuery: PaginatedQuery<PaginatedResultDto<RecipeDto>>
    {
        public Guid? ProductSizeId { get; set; }
        public Guid? IngredientId { get; set; }
        public UnitOfMeasurementType? Unit { get; set; }
        public Decimal? Quantity { get; set; }
    }
}
