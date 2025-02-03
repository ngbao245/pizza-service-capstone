using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.UpdateOrderVoucher
{
    public class UpdateOrderVoucherCommand : IRequest
	{
		public Guid? Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid VoucherId { get; set; }
    }
}
