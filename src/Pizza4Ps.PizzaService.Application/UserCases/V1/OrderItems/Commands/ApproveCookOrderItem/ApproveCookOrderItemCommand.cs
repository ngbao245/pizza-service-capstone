using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.ApproveCookOrderItem
{
    public class ApproveCookOrderItemCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
