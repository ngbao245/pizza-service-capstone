using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetOptionItemOrderItemById
{
    public class GetOptionItemOrderItemByIdQuery : IRequest<OptionItemOrderItemDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
