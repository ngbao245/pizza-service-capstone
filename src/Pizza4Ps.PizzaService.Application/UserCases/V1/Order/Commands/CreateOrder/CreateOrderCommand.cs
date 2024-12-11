using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Commands.CreateVoucher;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.CreateOrder
{
	public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
	{
		public DateTimeOffset StartTime { get; set; }
		public DateTimeOffset EndTime { get; set; }
		public string? Status { get; set; }
		public Guid OrderInTableId { get; set; }
	}
}
