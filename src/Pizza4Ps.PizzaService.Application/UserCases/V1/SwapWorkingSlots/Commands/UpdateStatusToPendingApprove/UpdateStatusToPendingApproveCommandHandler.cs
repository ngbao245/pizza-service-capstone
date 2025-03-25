using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.UpdateStatusToPendingApprove
{
    public class UpdateStatusToPendingApproveCommandHandler : IRequestHandler<UpdateStatusToPendingApproveCommand>
    {
        private readonly ISwapWorkingSlotService _swapWorkingSlotService;

        public UpdateStatusToPendingApproveCommandHandler(ISwapWorkingSlotService swapWorkingSlotService)
        {
            _swapWorkingSlotService = swapWorkingSlotService;
        }

        public async Task Handle(UpdateStatusToPendingApproveCommand request, CancellationToken cancellationToken)
        {
            await _swapWorkingSlotService.UpdateStatusToPendingApproveAsync(request.Id!.Value);
        }
    }
}
