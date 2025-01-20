using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetOptionById
{
    public class GetOptionByIdQuery : IRequest<OptionDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
