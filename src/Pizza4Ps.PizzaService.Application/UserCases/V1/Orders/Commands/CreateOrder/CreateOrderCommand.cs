using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<ResultDto<Guid>>
	{
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string Status { get; set; }
        public Guid TableId { get; set; }
    }
}
