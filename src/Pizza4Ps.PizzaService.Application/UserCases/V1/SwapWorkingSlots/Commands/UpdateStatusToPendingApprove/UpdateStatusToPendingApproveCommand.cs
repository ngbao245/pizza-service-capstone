using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.UpdateStatusToPendingApprove
{
    public class UpdateStatusToPendingApproveCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
