using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem
{
	public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand>
	{
		private readonly IOrderItemService _orderitemService;

		public UpdateOrderItemCommandHandler(IOrderItemService orderitemService)
		{
			_orderitemService = orderitemService;
		}

		public async Task Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderitemService.UpdateAsync(
				request.Id!.Value,
				request.Name,
				request.Quantity,
				request.Price,
				request.OrderId,
				request.ProductId);
		}
	}
}
