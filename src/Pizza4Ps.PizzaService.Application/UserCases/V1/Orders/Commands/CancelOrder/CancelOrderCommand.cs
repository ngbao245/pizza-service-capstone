using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Note { get; set; }
    }
}
