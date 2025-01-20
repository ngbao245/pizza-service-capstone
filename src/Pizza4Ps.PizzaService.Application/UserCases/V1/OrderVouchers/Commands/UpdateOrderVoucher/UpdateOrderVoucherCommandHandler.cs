using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.UpdateOrderVoucher
{
	public class UpdateOrderVoucherCommandHandler : IRequestHandler<UpdateOrderVoucherCommand>
	{
		private readonly IOrderVoucherService _orderVoucherService;

		public UpdateOrderVoucherCommandHandler(IOrderVoucherService orderVoucherService)
		{
			_orderVoucherService = orderVoucherService;
		}

		public async Task Handle(UpdateOrderVoucherCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderVoucherService.UpdateAsync(
				request.Id!.Value,
				request.OrderId,
				request.VoucherId);
		}
	}
}
