using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Ingredients.Commands.RestoreIngredient
{
    public class RestoreIngredientCommandHandler : IRequestHandler<RestoreIngredientCommand>
    {
        private readonly IIngredientService _ingredientService;

        public RestoreIngredientCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task Handle(RestoreIngredientCommand request, CancellationToken cancellationToken)
        {
            await _ingredientService.RestoreAsync(request.Ids);
        }
    }
}
