using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.ApproveCookOrderItem
{
    public class ApproveCookOrderItemCommandHandler : IRequestHandler<ApproveCookOrderItemCommand>
    {
        private readonly IOrderItemService _orderItemService;

        public ApproveCookOrderItemCommandHandler(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public async Task Handle(ApproveCookOrderItemCommand request, CancellationToken cancellationToken)
        {
            await _orderItemService.ApproveCookingAsync(request.Id!.Value);
        }
    }
}
