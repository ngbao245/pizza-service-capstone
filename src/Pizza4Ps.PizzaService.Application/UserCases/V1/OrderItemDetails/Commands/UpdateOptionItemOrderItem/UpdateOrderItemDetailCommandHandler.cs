using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.UpdateOptionItemOrderItem
{
	public class UpdateOrderItemDetailCommandHandler : IRequestHandler<UpdateOrderItemDetailCommand>
	{
		private readonly IOrderItemDetailService _orderItemDetailService;

        public UpdateOrderItemDetailCommandHandler(IOrderItemDetailService orderItemDetailService)
        {
            _orderItemDetailService = orderItemDetailService;
        }

        public async Task Handle(UpdateOrderItemDetailCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderItemDetailService.UpdateAsync(
				request.Id!.Value,
				request.Name,
				request.AdditionalPrice,
				request.OptionItemId,
				request.OrderItemId);
		}
	}
}
