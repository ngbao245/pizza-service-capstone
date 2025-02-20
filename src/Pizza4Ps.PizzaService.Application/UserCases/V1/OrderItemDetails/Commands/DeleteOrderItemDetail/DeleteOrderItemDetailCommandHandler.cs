using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.DeleteOptionItemOrderItem
{
    public class DeleteOrderItemDetailCommandHandler : IRequestHandler<DeleteOrderItemDetailCommand>
    {
        private readonly IOrderItemDetailService _orderItemDetailService;

        public DeleteOrderItemDetailCommandHandler(IOrderItemDetailService orderItemDetailService)
        {
            _orderItemDetailService = orderItemDetailService;
        }

        public async Task Handle(DeleteOrderItemDetailCommand request, CancellationToken cancellationToken)
        {
            await _orderItemDetailService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
