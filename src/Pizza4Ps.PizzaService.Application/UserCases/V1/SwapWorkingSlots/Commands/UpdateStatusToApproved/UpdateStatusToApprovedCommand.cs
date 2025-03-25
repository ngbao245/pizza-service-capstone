using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.UpdateStatusToApproved
{
    public class UpdateStatusToApprovedCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
