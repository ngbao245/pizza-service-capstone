using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateStatusToServingCommandHandler : IRequestHandler<UpdateStatusToServingCommand>
    {
        private readonly IOrderItemService _orderItemService;

        public UpdateStatusToServingCommandHandler(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public async Task Handle(UpdateStatusToServingCommand request, CancellationToken cancellationToken)
        {
            await _orderItemService.UpdateStatusToServingAsync(request.Id!.Value, request.OrderId);
        }
    }
}
