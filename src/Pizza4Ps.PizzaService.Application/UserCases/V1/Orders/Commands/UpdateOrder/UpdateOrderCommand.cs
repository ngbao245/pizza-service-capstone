using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
	{
		public Guid? Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string Status { get; set; }
        public Guid TableId { get; set; }
    }
}
