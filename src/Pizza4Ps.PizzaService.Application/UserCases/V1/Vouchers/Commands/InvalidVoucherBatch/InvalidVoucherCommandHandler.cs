using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.InvalidVoucherBatch
{
    public class InvalidVoucherCommandHandler : IRequestHandler<InvalidVoucherBatchCommand>
    {
        private readonly IVoucherBatchRepository _voucherBatchRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InvalidVoucherCommandHandler(IVoucherBatchRepository voucherBatchRepository, IUnitOfWork unitOfWork)
        {
            _voucherBatchRepository = voucherBatchRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(InvalidVoucherBatchCommand request, CancellationToken cancellationToken)
        {
            var voucherBatch = await _voucherBatchRepository.GetSingleByIdAsync(request.VoucherBatchId, "Vouchers");
            if (voucherBatch == null)
            {
                throw new BusinessException("Đợt voucher không tồn tại.");
            }
            voucherBatch.SetInvalid();

            if (voucherBatch.Vouchers.Count > 0)
            {
                foreach (var voucher in voucherBatch.Vouchers)
                {
                    if (voucher.VoucherStatus != Domain.Enums.VoucherStatus.Used)
                    {
                        voucher.SetInvalid();
                    }
                }
            }

            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
