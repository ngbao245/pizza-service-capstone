using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Queries.GetListRecipe
{
    public class GetListRecipeQueryHandler : IRequestHandler<GetListRecipeQuery, PaginatedResultDto<RecipeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _recipeRepository;

        public GetListRecipeQueryHandler(IMapper mapper, IRecipeRepository recipeRepository)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
        }

        public async Task<PaginatedResultDto<RecipeDto>> Handle(GetListRecipeQuery request, CancellationToken cancellationToken)
        {
            UnitOfMeasurementType? unitType = null;
            if (!string.IsNullOrEmpty(request.Unit))
            {
                if (!Enum.TryParse(request.Unit, true, out UnitOfMeasurementType parsedType))
                {
                    throw new BusinessException(BussinessErrorConstants.RecipeErrorConstant.RECIPE_UNIT_INVALID);
                }
                unitType = parsedType;
            }

            var query = _recipeRepository.GetListAsNoTracking(
                x => (request.ProductSizeId == null || x.ProductSizeId == request.ProductSizeId)
                && (request.IngredientId == null || x.IngredientId == request.IngredientId)
                && (request.IngredientName== null || x.IngredientName == request.IngredientName)
                && (unitType == null || x.Unit == unitType)
                && (request.Quantity == null || x.Quantity == request.Quantity),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.RecipeErrorConstant.RECIPE_NOT_FOUND);
            var result = _mapper.Map<List<RecipeDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<RecipeDto>(result, totalCount);
        }
    }
}
