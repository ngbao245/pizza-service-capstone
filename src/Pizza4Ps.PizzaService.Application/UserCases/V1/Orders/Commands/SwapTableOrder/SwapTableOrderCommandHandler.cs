using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.SwapTableOrder
{
    public class SwapTableOrderCommandHandler : IRequestHandler<SwapTableOrderCommand>
    {
        private readonly IOrderService _orderService;

        public SwapTableOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Handle(SwapTableOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.SwapTableOrder(request.OrderId, request.NewTableId);
        }
    }
}
