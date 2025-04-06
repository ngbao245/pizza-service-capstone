using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToDone
{
    public class UpdateStatusToDoneCommandHandler : IRequestHandler<UpdateStatusToDoneCommand>
    {
        private readonly IOrderItemService _orderItemService;

        public UpdateStatusToDoneCommandHandler(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public async Task Handle(UpdateStatusToDoneCommand request, CancellationToken cancellationToken)
        {
            await _orderItemService.DoneServingAsync(request.Id!.Value);
        }
    }
}
