using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.UpdateStatusToRejected
{
    public class UpdateStatusToRejectedCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
