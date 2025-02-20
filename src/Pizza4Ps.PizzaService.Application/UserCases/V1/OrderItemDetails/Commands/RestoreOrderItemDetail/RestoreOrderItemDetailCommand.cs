using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.RestoreOptionItemOrderItem
{
	public class RestoreOrderItemDetailCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
