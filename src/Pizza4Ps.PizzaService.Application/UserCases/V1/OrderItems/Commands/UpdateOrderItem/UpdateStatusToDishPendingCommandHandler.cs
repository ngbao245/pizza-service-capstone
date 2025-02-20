using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateStatusToDishPendingCommandHandler : IRequestHandler<UpdateStatusToDishPendingCommand>
    {
        private readonly IOrderItemService _orderItemService;

        public UpdateStatusToDishPendingCommandHandler(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public async Task Handle(UpdateStatusToDishPendingCommand request, CancellationToken cancellationToken)
        {
            await _orderItemService.UpdateStatusToPendingAsync(request.Id!.Value, request.OrderId);
        }
    }
}
