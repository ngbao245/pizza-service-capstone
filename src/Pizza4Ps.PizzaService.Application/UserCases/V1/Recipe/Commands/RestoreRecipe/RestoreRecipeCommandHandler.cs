using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.RestoreRecipe
{
    public class RestoreRecipeCommandHandler: IRequestHandler<RestoreRecipeCommand>
    {
        private readonly IRecipeService _recipeService;

        public RestoreRecipeCommandHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task Handle(RestoreRecipeCommand request, CancellationToken cancellationToken)
        {
            await _recipeService.RestoreAsync(request.Ids);
        }
    }
}
