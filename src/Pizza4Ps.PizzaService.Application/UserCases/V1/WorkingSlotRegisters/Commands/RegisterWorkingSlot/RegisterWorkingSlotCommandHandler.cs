using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.RegisterWorkingSlot
{
    public class RegisterWorkingSlotCommandHandler : IRequestHandler<RegisterWorkingSlotCommand, ResultDto<Guid>>
    {
        private readonly IWorkingSlotRegisterService _workingSlotRegisterService;

        public RegisterWorkingSlotCommandHandler(IWorkingSlotRegisterService workingSlotRegisterService)
        {
            _workingSlotRegisterService = workingSlotRegisterService;
        }

        public async Task<ResultDto<Guid>> Handle(RegisterWorkingSlotCommand request, CancellationToken cancellationToken)
        {
            var result = await _workingSlotRegisterService.RegisterWorkingSlotAsync(
                request.WorkingDate,
                request.StaffId, 
                request.WorkingSlotId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}