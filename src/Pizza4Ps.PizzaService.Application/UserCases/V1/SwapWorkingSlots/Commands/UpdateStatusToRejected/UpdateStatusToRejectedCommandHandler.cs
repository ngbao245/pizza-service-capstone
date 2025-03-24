using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToDone;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.UpdateStatusToRejected
{
    public class UpdateStatusToRejectedCommandHandler : IRequestHandler<UpdateStatusToRejectedCommand>
    {
        private readonly ISwapWorkingSlotService _swapWorkingSlotService;

        public UpdateStatusToRejectedCommandHandler(ISwapWorkingSlotService swapWorkingSlotService)
        {
            _swapWorkingSlotService = swapWorkingSlotService;
        }

        public async Task Handle(UpdateStatusToRejectedCommand request, CancellationToken cancellationToken)
        {
            await _swapWorkingSlotService.UpdateStatusToPendingApproveAsync(request.Id!.Value);
        }
    }
}
