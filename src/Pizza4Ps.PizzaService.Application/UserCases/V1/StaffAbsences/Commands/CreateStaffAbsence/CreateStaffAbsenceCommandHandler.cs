using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Commands.CreateStaffAbsence
{
    public class CreateStaffAbsenceCommandHandler : IRequestHandler<CreateStaffAbsenceCommand, ResultDto<Guid>>
    {
        private readonly IStaffAbsenceService _staffAbsenceService;

        public CreateStaffAbsenceCommandHandler(IStaffAbsenceService staffAbsenceService)
        {
            _staffAbsenceService = staffAbsenceService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateStaffAbsenceCommand request, CancellationToken cancellationToken)
        {
            var result = await _staffAbsenceService.CreateAsync(request.StaffId, request.WorkingSlotId, request.AbsentDate);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
