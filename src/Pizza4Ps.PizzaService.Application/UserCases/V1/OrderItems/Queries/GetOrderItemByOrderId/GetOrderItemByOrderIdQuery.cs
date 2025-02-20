using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemByOrderId
{
    public class GetOrderItemByOrderIdQuery : IRequest<List<OrderItemDto>>
    {
        public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
    }
}
