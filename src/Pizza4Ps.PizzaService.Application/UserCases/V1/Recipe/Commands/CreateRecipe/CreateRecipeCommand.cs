using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.CreateRecipe
{
    public class CreateRecipeCommand : IRequest<ResultDto<Guid>>
    {
        public Guid ProductSizeId { get; set; }
        public Guid IngredientId { get; set; }
        public UnitOfMeasurementType Unit { get; set; }
        public Decimal Quantity { get; set; }
    }
}
