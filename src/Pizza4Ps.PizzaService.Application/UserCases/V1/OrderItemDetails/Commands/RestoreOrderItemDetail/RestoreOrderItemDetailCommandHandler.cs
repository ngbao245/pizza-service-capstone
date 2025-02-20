using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.RestoreOptionItemOrderItem
{
    public class RestoreOrderItemDetailCommandHandler : IRequestHandler<RestoreOrderItemDetailCommand>
    {
        private readonly IOrderItemDetailService _orderItemDetailService;

        public RestoreOrderItemDetailCommandHandler(IOrderItemDetailService orderItemDetailService)
        {
            _orderItemDetailService = orderItemDetailService;
        }

        public async Task Handle(RestoreOrderItemDetailCommand request, CancellationToken cancellationToken)
        {
            await _orderItemDetailService.RestoreAsync(request.Ids);
        }
    }
}
