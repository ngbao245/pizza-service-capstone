using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetVoucherByCode
{
    public class GetVoucherByCodeQueryHandler : IRequestHandler<GetVoucherByCodeQuery, VoucherDto>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherRepository _voucherRepository;

        public GetVoucherByCodeQueryHandler(IVoucherRepository voucherRepository, IMapper mapper)
        {
            _mapper = mapper;
            _voucherRepository = voucherRepository;
        }
        public async Task<VoucherDto> Handle(GetVoucherByCodeQuery request, CancellationToken cancellationToken)
        {
            var voucher = await _voucherRepository.GetSingleAsync(x => x.Code == request.Code, cancellationToken: cancellationToken);
            if (voucher == null)
            {
                throw new BusinessException($"Không tìm thấy voucher có mã code {request.Code}");
            }
            return _mapper.Map<VoucherDto>(voucher);
        }
    }
}
