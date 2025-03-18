using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Ingredients.Queries.GetIngredientById
{
    public class GetIngredientByIdQueryHandler : IRequestHandler<GetIngredientByIdQuery, IngredientDto>
    {
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _IngredientRepository;

        public GetIngredientByIdQueryHandler(IMapper mapper, IIngredientRepository IngredientRepository)
        {
            _mapper = mapper;
            _IngredientRepository = IngredientRepository;
        }

        public async Task<IngredientDto> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _IngredientRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<IngredientDto>(entity);
            return result;
        }
    }
}
