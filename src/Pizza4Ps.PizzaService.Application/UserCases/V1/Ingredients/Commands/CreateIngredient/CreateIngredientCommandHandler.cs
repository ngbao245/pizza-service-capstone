using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, ResultDto<Guid>>
    {
        private readonly IIngredientService _IngredientService;

        public CreateIngredientCommandHandler(IIngredientService IngredientService)
        {
            _IngredientService = IngredientService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var result = await _IngredientService.CreateAsync(
                request.Name,
                request.Description,
                request.Price);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
