using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.UpdateProduct;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.UpdateOrder
{
	public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResponse>
	{
		private readonly IOrderService _orderService;

		public UpdateOrderCommandHandler(IOrderService orderService)
		{
			_orderService = orderService;
		}

		public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderService.UpdateAsync(request.Id, request.StartTime, request.EndTime, request.Status, request.OrderInTableId);
			return new UpdateOrderCommandResponse
			{
				Id = result
			};
		}
	}
}
