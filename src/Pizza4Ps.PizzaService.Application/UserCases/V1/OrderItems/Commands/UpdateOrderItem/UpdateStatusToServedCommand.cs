using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateStatusToServedCommand : IRequest
    {
        public Guid? Id { get; set; }
        public Guid OrderId { get; set; }
    }
}
