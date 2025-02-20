using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.UpdateOrder
{
    public class UpdateStatusToCompleteCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
