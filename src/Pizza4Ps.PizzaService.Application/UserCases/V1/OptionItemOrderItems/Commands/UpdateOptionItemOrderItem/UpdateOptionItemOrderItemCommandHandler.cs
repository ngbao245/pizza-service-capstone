using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.UpdateOptionItemOrderItem
{
	public class UpdateOptionItemOrderItemCommandHandler : IRequestHandler<UpdateOptionItemOrderItemCommand>
	{
		private readonly IOptionItemOrderItemService _optionitemorderitemService;

		public UpdateOptionItemOrderItemCommandHandler(IOptionItemOrderItemService optionitemorderitemService)
		{
			_optionitemorderitemService = optionitemorderitemService;
		}

		public async Task Handle(UpdateOptionItemOrderItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionitemorderitemService.UpdateAsync(
				request.Id!.Value,
				request.Name,
				request.AdditionalPrice,
				request.OptionItemId,
				request.OrderItemId);
		}
	}
}
