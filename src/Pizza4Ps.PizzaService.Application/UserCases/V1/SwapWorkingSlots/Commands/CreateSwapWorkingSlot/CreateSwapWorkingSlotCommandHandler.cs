using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.CreateSwapWorkingSlot
{
    public class CreateSwapWorkingSlotCommandHandler : IRequestHandler<CreateSwapWorkingSlotCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ISwapWorkingSlotService _swapWorkingSlotService;

        public CreateSwapWorkingSlotCommandHandler(IMapper mapper, ISwapWorkingSlotService swapWorkingSlotService)
        {
            _mapper = mapper;
            _swapWorkingSlotService = swapWorkingSlotService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateSwapWorkingSlotCommand request, CancellationToken cancellationToken)
        {
            var result = await _swapWorkingSlotService.CreateAsync(
                request.EmployeeFromId,
                request.EmployeeToId,
                request.WorkingSlotFromId,
                request.WorkingSlotToId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
