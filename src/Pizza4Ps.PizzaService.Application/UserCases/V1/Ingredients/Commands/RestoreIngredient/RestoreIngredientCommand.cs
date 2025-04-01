using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Ingredients.Commands.RestoreIngredient
{
    public class RestoreIngredientCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
