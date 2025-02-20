using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToServed
{
    public class UpdateStatusToServingCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
