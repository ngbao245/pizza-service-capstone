using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeService _recipeService;

        public CreateRecipeCommandHandler(IMapper mapper, IRecipeService recipeService)
        {
            _mapper = mapper;
            _recipeService = recipeService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var result = await _recipeService.CreateAsync(
                request.ProductSizeId,
                request.IngredientId,
                request.Unit,
                request.Quantity
                );
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
