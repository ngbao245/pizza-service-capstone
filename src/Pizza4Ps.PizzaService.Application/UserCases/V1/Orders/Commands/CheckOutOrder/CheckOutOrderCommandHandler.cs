//using MediatR;
//using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
//using Pizza4Ps.PizzaService.Domain.Services;

//namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CheckOutOrder
//{
//    public class CheckOutOrderCommandHandler : IRequestHandler<CheckOutOrderCommand>
//    {
//        private readonly IOrderService _orderService;

//        public CheckOutOrderCommandHandler(IOrderService orderService)
//        {
//            _orderService = orderService;
//        }
//        public Task Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
//        {
//            var order = _orderService.CheckOutOrder(request.OrderId);
//        }
//    }
//}
