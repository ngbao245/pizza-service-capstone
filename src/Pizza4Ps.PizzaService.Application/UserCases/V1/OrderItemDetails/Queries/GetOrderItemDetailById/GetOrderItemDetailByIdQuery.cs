using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetOptionItemOrderItemById
{
    public class GetOrderItemDetailByIdQuery : IRequest<OrderItemDetailDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
