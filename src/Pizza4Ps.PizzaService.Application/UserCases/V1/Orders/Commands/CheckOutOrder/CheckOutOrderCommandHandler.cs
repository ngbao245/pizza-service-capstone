using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CheckOutOrder
{
    public class CheckOutOrderCommandHandler : IRequestHandler<CheckOutOrderCommand>
    {
        private readonly IOrderService _orderService;

        public CheckOutOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.CheckOutOrder(request.OrderId);
        }
    }
}
