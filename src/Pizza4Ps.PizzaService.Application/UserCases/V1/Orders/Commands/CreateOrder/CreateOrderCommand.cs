using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<ResultDto<Guid>>
	{
        public Guid TableId { get; set; }
    }
}
