using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
