using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
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
            var query = _recipeRepository.GetListAsNoTracking(
                x => (request.Unit == null || x.Unit.Contains(request.Unit))
                && (request.Name == null || x.Name.Contains(request.Name))
                ,
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
