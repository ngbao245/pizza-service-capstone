using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.UserVoucher
{
    public class UserVoucherCommandHandler : IRequestHandler<UserVoucherCommand, bool>
    {
        private readonly IVoucherService _voucherService;
        private readonly IUnitOfWork _unitOfWork;

        public UserVoucherCommandHandler(IVoucherService voucherService, IUnitOfWork unitOfWork)
        {
            _voucherService = voucherService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UserVoucherCommand request, CancellationToken cancellationToken)
        {
            var result = await _voucherService.UserVoucherAsync(request.OrderId, request.Code);
            return result;
        }
    }
}
