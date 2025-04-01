using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.DeleteRecipe
{
    public class DeleteRecipeCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}
