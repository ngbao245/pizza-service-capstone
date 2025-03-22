using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.UpdateStatusToRejected
{
    public class UpdateStatusToRejectedCommandHandler : IRequestHandler<UpdateStatusToRejectedCommand>
    {
        private readonly IWorkingSlotRegisterService _workingSlotRegisterService;

        public UpdateStatusToRejectedCommandHandler(IWorkingSlotRegisterService workingSlotRegisterService)
        {
            _workingSlotRegisterService = workingSlotRegisterService;
        }

        public async Task Handle(UpdateStatusToRejectedCommand request, CancellationToken cancellationToken)
        {
            await _workingSlotRegisterService.UpdateStatusToRejectedAsync(request.Id!.Value);
        }
    }
}
