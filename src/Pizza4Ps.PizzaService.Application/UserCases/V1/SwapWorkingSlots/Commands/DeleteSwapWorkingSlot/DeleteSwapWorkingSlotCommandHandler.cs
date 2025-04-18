using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.DeleteSwapWorkingSlot
{
    public class DeleteSwapWorkingSlotCommandHandler : IRequestHandler<DeleteSwapWorkingSlotCommand>
    {
        private readonly ISwapWorkingSlotService _swapWorkingSlotService;

        public DeleteSwapWorkingSlotCommandHandler(ISwapWorkingSlotService swapWorkingSlotService)
        {
            _swapWorkingSlotService = swapWorkingSlotService;
        }

        public async Task Handle(DeleteSwapWorkingSlotCommand request, CancellationToken cancellationToken)
        {
            await _swapWorkingSlotService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
