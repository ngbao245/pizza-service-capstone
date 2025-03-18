using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AdditionalFees.Queries.GetListAdditionalFee
{
    public class GetListAdditionalFeeQueryHandler : IRequestHandler<GetListAdditionalFeeQuery, PaginatedResultDto<AdditionalFeeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalFeeRepository _AdditionalFeeRepository;

        public GetListAdditionalFeeQueryHandler(IMapper mapper, IAdditionalFeeRepository AdditionalFeeRepository)
        {
            _mapper = mapper;
            _AdditionalFeeRepository = AdditionalFeeRepository;
        }

        public async Task<PaginatedResultDto<AdditionalFeeDto>> Handle(GetListAdditionalFeeQuery request, CancellationToken cancellationToken)
        {
            var query = _AdditionalFeeRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description)),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.AdditionalFeeErrorConstant.ADDITIONAL_FEE_NOT_FOUND);
            var result = _mapper.Map<List<AdditionalFeeDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<AdditionalFeeDto>(result, totalCount);
        }
    }
}
