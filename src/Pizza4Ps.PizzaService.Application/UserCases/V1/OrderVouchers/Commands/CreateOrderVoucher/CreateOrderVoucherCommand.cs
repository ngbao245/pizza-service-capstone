using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.CreateOrderVoucher
{
    public class CreateOrderVoucherCommand : IRequest<ResultDto<Guid>>
	{
        public Guid OrderId { get; set; }
        public Guid VoucherId { get; set; }
    }
}
