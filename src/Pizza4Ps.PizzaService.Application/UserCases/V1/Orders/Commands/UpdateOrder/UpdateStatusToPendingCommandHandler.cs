using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.UpdateOrder
{
    public class UpdateStatusToPendingCommandHandler : IRequestHandler<UpdateStatusToPendingCommand>
    {
        private readonly IOrderService _orderService;

        public UpdateStatusToPendingCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Handle(UpdateStatusToPendingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
