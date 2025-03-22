using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Commands.CreateWorkingSlot
{
    public class CreateWorkingSlotCommandHandler : IRequestHandler<CreateWorkingSlotCommand, ResultDto<Guid>>
    {
        private readonly IWorkingSlotService _workingslotService;

        public CreateWorkingSlotCommandHandler(IWorkingSlotService workingslotService)
        {
            _workingslotService = workingslotService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateWorkingSlotCommand request, CancellationToken cancellationToken)
        {
            var result = await _workingslotService.CreateAsync(
                request.ShiftStart,
                request.ShiftEnd,
                request.Capacity,
                request.DayId,
                request.ShiftId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}