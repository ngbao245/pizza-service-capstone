using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Ingredients.Queries.GetListIngredient
{
    public class GetListIngredientQueryHandler : IRequestHandler<GetListIngredientQuery, PaginatedResultDto<IngredientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _IngredientRepository;

        public GetListIngredientQueryHandler(IMapper mapper, IIngredientRepository IngredientRepository)
        {
            _mapper = mapper;
            _IngredientRepository = IngredientRepository;
        }

        public async Task<PaginatedResultDto<IngredientDto>> Handle(GetListIngredientQuery request, CancellationToken cancellationToken)
        {
            var query = _IngredientRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                ,
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.IngredientErrorConstant.INGREDIENT_NOT_FOUND);
            var result = _mapper.Map<List<IngredientDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<IngredientDto>(result, totalCount);
        }
    }
}