using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CancelCheckOut
{
    public class CancelCheckOutCommandHandler : IRequestHandler<CancelCheckOutCommand>
    {
        private readonly IOrderService _orderService;

        public CancelCheckOutCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Handle(CancelCheckOutCommand request, CancellationToken cancellationToken)
        {
            await _orderService.CancelCheckOut(request.OrderId);
        }
    }
}
