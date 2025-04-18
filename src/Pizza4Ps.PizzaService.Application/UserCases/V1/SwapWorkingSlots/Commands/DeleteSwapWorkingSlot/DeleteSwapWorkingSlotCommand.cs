using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.DeleteSwapWorkingSlot
{
    public class DeleteSwapWorkingSlotCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}

