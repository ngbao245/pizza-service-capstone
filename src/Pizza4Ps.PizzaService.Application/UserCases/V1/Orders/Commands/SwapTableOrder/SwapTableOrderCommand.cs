using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.SwapTableOrder
{
    public class SwapTableOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public Guid NewTableId { get; set; }
    }
}
