using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.RestoreRecipe
{
    public class RestoreRecipeCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
