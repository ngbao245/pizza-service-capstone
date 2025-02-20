using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.UpdateOrder
{
    public class UpdateStatusToCompleteCommandHandler : IRequestHandler<UpdateStatusToCompleteCommand>
    {
        private readonly IOrderService _orderService;

        public UpdateStatusToCompleteCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Handle(UpdateStatusToCompleteCommand request, CancellationToken cancellationToken)
        {
            await _orderService.UpdateStatusToCompleteAsync(request.Id!.Value);
        }
    }
}
