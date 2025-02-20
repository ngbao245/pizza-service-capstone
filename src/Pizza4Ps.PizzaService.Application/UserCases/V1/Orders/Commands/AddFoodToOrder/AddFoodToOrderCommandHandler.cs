using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.AddFoodToOrder
{
    public class AddFoodToOrderCommandHandler : IRequestHandler<AddFoodToOrderCommand, ResultDto<Guid>>
    {
        private readonly IOrderService _orderService;

        public AddFoodToOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<ResultDto<Guid>> Handle(AddFoodToOrderCommand request, CancellationToken cancellationToken)
        {
            var orderItems = request.OrderItems
                .Select(item => (item.ProductId, item.OptionItemIds, item.Note))
                .ToList();

            var orderId = await _orderService.AddFoodToOrderAsync(request.TableId, orderItems);
            return new ResultDto<Guid> { Id = orderId };
        }
    }
}