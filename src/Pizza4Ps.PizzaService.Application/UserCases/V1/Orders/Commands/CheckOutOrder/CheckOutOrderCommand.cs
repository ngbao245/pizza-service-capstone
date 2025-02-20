using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CheckOutOrder
{
    public class CheckOutOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
