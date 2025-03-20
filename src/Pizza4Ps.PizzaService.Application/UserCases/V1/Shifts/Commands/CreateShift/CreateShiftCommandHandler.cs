using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Shifts.Commands.CreateShift
{
    public class CreateShiftCommandHandler : IRequestHandler<CreateShiftCommand, ResultDto<Guid>>
    {
        private readonly IShiftService _ShiftService;

        public CreateShiftCommandHandler(IShiftService ShiftService)
        {
            _ShiftService = ShiftService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
        {
            var result = await _ShiftService.CreateAsync(
                request.Name,
                request.Description);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
