using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.UpdateStatusToApproved
{
    public class UpdateStatusToApprovedCommandHandler : IRequestHandler<UpdateStatusToApprovedCommand>
    {
        private readonly IWorkingSlotRegisterService _workingSlotRegisterService;

        public UpdateStatusToApprovedCommandHandler(IWorkingSlotRegisterService workingSlotRegisterService)
        {
            _workingSlotRegisterService = workingSlotRegisterService;
        }

        public async Task Handle(UpdateStatusToApprovedCommand request, CancellationToken cancellationToken)
        {
            await _workingSlotRegisterService.UpdateStatusToApprovedAsync(request.Id!.Value);
        }
    }
}
