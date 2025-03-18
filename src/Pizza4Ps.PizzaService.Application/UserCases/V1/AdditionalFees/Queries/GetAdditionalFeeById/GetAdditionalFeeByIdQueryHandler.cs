using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AdditionalFees.Queries.GetAdditionalFeeById
{
    public class GetAdditionalFeeByIdQueryHandler : IRequestHandler<GetAdditionalFeeByIdQuery, AdditionalFeeDto>
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalFeeRepository _AdditionalFeeRepository;

        public GetAdditionalFeeByIdQueryHandler(IMapper mapper, IAdditionalFeeRepository AdditionalFeeRepository)
        {
            _mapper = mapper;
            _AdditionalFeeRepository = AdditionalFeeRepository;
        }

        public async Task<AdditionalFeeDto> Handle(GetAdditionalFeeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _AdditionalFeeRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<AdditionalFeeDto>(entity);
            return result;
        }
    }
}
