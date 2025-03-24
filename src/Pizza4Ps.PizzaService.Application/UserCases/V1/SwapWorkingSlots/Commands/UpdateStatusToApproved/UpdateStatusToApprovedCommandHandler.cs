using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.UpdateStatusToApproved
{
    public class UpdateStatusToApprovedCommandHandler : IRequestHandler<UpdateStatusToApprovedCommand>
    {
        private readonly ISwapWorkingSlotService _swapWorkingSlotService;

        public UpdateStatusToApprovedCommandHandler(ISwapWorkingSlotService swapWorkingSlotService)
        {
            _swapWorkingSlotService = swapWorkingSlotService;
        }

        public async Task Handle(UpdateStatusToApprovedCommand request, CancellationToken cancellationToken)
        {
            await _swapWorkingSlotService.UpdateStatusToApprovedAsync(request.Id!.Value);
        }
    }
}
