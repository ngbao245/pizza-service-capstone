using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToCancelled
{
    public class UpdateStatusToCancelledCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
