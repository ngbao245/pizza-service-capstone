using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherBatchs.Queries.GetVoucherBatchById
{
    public class GetVoucherBatchByIdQueryHandler : IRequestHandler<GetVoucherBatchByIdQuery, VoucherBatchDto>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherBatchRepository _VoucherTypeRepository;

        public GetVoucherBatchByIdQueryHandler(IMapper mapper, IVoucherBatchRepository VoucherTypeRepository)
        {
            _mapper = mapper;
            _VoucherTypeRepository = VoucherTypeRepository;
        }

        public async Task<VoucherBatchDto> Handle(GetVoucherBatchByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _VoucherTypeRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<VoucherBatchDto>(entity);
            return result;
        }
    }
}
