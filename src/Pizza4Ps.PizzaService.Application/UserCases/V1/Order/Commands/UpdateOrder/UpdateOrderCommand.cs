using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.UpdateOrder
{
	public class UpdateOrderCommand : BaseUpdateCommand<Guid>, IRequest<UpdateOrderCommandResponse>
	{
		public DateTimeOffset StartTime { get; set; }
		public DateTimeOffset EndTime { get; set; }
		public string? Status { get; set; }
		public Guid OrderInTableId { get; set; }
	}
}
