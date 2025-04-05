using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.UserVoucher
{
    public class UserVoucherCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public string Code { get; set; }
    }
}
