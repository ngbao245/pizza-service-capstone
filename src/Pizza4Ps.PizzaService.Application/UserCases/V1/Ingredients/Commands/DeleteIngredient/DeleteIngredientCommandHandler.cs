using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand>
    {
        private readonly IIngredientService _ingredientService;

        public DeleteIngredientCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            await _ingredientService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
