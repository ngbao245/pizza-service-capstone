using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Queries.GetRecipeById
{
    public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, RecipeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _recipeRepository;

        public GetRecipeByIdQueryHandler(IMapper mapper, IRecipeRepository recipeRepository)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
        }

        public async Task<RecipeDto> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _recipeRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<RecipeDto>(entity);
            return result;
        }
    }
}
