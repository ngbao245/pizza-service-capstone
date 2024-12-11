using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Commands.CreateVoucher
{
    public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, CreateVoucherCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherService _voucherService;

        public CreateVoucherCommandHandler(IMapper mapper, IVoucherService voucherService)
        {
            _mapper = mapper;
            _voucherService = voucherService;
        }

        public async Task<CreateVoucherCommandResponse> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
        {
            var result = await _voucherService.CreateAsync(request.Code, request.DiscountType, request.ExpiryDate);
            return new CreateVoucherCommandResponse
            {
                Id = result
            };
        }
    }
}
