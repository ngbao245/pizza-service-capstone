using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.UpdateOrder
{
	public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
	{
		private readonly IOrderService _orderService;

		public UpdateOrderCommandHandler(IOrderService orderService)
		{
			_orderService = orderService;
		}

		public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderService.UpdateAsync(
				request.Id!.Value,
				request.StartTime,
				request.EndTime,
				request.Status,
				request.TableId);
		}
	}
}
