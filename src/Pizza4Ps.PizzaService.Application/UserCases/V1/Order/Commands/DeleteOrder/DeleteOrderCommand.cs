using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.DeleteOrder
{
	public class DeleteOrderCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
