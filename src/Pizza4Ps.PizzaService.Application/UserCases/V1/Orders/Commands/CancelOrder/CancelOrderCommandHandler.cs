using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrderService _orderService;

        public CancelOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.CancelOrder(request.Id, request.Note);
        }
    }
}
