using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CancelCheckOut
{
    public class CancelCheckOutCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
