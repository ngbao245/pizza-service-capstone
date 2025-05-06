using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.InvalidVoucherBatch
{
    public class InvalidVoucherBatchCommand
         : IRequest
    {
        public Guid VoucherBatchId { get; set; } // ID của đợt voucher
}
}
