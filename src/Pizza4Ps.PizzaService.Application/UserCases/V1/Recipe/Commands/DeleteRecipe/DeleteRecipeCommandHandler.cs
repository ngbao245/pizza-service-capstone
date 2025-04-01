using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.DeleteRecipe
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private readonly IRecipeService _recipeService;

        public DeleteRecipeCommandHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            await _recipeService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
