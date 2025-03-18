using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Queries.GetVoucherTypeById
{
    public class GetVoucherTypeByIdQueryHandler : IRequestHandler<GetVoucherTypeByIdQuery, VoucherTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherTypeRepository _VoucherTypeRepository;

        public GetVoucherTypeByIdQueryHandler(IMapper mapper, IVoucherTypeRepository VoucherTypeRepository)
        {
            _mapper = mapper;
            _VoucherTypeRepository = VoucherTypeRepository;
        }

        public async Task<VoucherTypeDto> Handle(GetVoucherTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _VoucherTypeRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<VoucherTypeDto>(entity);
            return result;
        }
    }
}
