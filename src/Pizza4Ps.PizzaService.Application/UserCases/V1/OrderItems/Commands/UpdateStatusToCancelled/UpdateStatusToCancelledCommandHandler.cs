using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToCancelled
{
    public class UpdateStatusToCancelledCommandHandler : IRequestHandler<UpdateStatusToCancelledCommand>
    {
        private readonly IOrderItemService _orderItemService;

        public UpdateStatusToCancelledCommandHandler(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public async Task Handle(UpdateStatusToCancelledCommand request, CancellationToken cancellationToken)
        {
            await _orderItemService.UpdateStatusToCancelledAsync(request.Id!.Value, request.Reason);
        }
    }
}
