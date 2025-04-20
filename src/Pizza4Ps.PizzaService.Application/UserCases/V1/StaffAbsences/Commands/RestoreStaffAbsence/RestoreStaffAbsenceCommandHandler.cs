using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Commands.RestoreStaffAbsence
{
    public class RestoreStaffAbsenceCommandHandler : IRequestHandler<RestoreStaffAbsenceCommand>
    {
        private readonly IStaffAbsenceService _StaffAbsenceService;

        public RestoreStaffAbsenceCommandHandler(IStaffAbsenceService StaffAbsenceService)
        {
            _StaffAbsenceService = StaffAbsenceService;
        }

        public async Task Handle(RestoreStaffAbsenceCommand request, CancellationToken cancellationToken)
        {
            await _StaffAbsenceService.RestoreAsync(request.Ids);
        }
    }
}
