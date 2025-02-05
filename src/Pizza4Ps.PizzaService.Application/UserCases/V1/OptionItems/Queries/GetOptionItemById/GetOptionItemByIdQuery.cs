using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetOptionItemById
{
    public class GetOptionItemByIdQuery : IRequest<OptionItemDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
