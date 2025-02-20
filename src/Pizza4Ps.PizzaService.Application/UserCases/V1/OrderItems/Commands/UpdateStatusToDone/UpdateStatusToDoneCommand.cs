using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToDone
{
    public class UpdateStatusToDoneCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
