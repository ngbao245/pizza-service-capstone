using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.AddFoodToOrder
{
    public class AddFoodToOrderCommandHandler : IRequestHandler<AddFoodToOrderCommand, ResultDto<bool>>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public AddFoodToOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<ResultDto<bool>> Handle(AddFoodToOrderCommand request, CancellationToken cancellationToken)
        {
            var orderItems = request.OrderItems
                .Select(item => (item.ProductId, item.OptionItemIds, item.Note))
                .ToList();

            var result = await _orderService.AddFoodToOrderAsync(request.TableId, orderItems);
            return new ResultDto<bool> { Id = result };
        }
    }
}