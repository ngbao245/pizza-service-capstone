using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

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
            UnitOfMeasurementType? unitOfMeasurementType = null;

            if (!Enum.TryParse(request.Unit, true, out UnitOfMeasurementType parsedStatus))
            {
                throw new BusinessException(BussinessErrorConstants.RecipeErrorConstant.RECIPE_NOT_INCLUDED_INGREDIENT);
            }
            unitOfMeasurementType = parsedStatus;

            var result = await _recipeService.CreateAsync(
                request.ProductSizeId,
                request.IngredientId,
                request.IngredientName,
                unitOfMeasurementType.Value,
                request.Quantity
                );
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
