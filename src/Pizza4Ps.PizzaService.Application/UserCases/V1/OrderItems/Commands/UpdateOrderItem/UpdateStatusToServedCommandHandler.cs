using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateStatusToServedCommandHandler : IRequestHandler<UpdateStatusToServedCommand>
    {
        private readonly IOrderItemService _orderItemService;

        public UpdateStatusToServedCommandHandler(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public async Task Handle(UpdateStatusToServedCommand request, CancellationToken cancellationToken)
        {
            await _orderItemService.UpdateStatusToServedAsync(request.Id!.Value, request.OrderId);
        }
    }
}
