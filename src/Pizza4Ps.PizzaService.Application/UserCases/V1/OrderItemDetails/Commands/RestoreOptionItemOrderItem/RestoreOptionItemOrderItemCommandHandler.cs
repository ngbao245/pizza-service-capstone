using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.RestoreOptionItemOrderItem
{
	public class RestoreOptionItemOrderItemCommandHandler : IRequestHandler<RestoreOptionItemOrderItemCommand>
	{
		private readonly IOrderItemDetailService _optionitemorderitemService;

		public RestoreOptionItemOrderItemCommandHandler(IOrderItemDetailService optionitemorderitemService)
		{
			_optionitemorderitemService = optionitemorderitemService;
		}

		public async Task Handle(RestoreOptionItemOrderItemCommand request, CancellationToken cancellationToken)
		{
			await _optionitemorderitemService.RestoreAsync(request.Ids);
		}
	}
}
