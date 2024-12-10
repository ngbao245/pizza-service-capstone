using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Commands.CreateVoucher
{
    public class CreateVoucherCommand : IRequest<CreateVoucherCommandResponse>
    {
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
