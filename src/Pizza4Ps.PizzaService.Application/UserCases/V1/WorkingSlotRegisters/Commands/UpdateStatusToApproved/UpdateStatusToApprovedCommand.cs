using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.UpdateStatusToApproved
{
    public class UpdateStatusToApprovedCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
