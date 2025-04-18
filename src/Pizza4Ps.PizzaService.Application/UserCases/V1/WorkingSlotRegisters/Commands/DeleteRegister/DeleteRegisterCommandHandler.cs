using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.DeleteRegister
{
    public class DeleteRegisterCommandHandler : IRequestHandler<DeleteRegisterCommand>
    {
        private readonly IWorkingSlotRegisterService _workingSlotRegisterService;

        public DeleteRegisterCommandHandler(IWorkingSlotRegisterService workingSlotRegisterService)
        {
            _workingSlotRegisterService = workingSlotRegisterService;
        }

        public async Task Handle(DeleteRegisterCommand request, CancellationToken cancellationToken)
        {
            await _workingSlotRegisterService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
