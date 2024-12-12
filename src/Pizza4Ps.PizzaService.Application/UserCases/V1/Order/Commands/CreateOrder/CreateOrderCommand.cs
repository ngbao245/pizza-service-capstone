using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.CreateOrder
{
	public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
	{
		public CreateOrderDto CreateOrderDto { get; set; }
	}
}
