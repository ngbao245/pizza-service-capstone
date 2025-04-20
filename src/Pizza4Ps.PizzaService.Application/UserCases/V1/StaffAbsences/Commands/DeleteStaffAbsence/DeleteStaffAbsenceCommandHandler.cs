using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Commands.DeleteStaffAbsence
{
    public class DeleteStaffAbsenceCommandHandler : IRequestHandler<DeleteStaffAbsenceCommand>
    {
        private readonly IStaffAbsenceService _staffAbsenceService;

        public DeleteStaffAbsenceCommandHandler(IStaffAbsenceService staffAbsenceService)
        {
            _staffAbsenceService = staffAbsenceService;
        }

        public async Task Handle(DeleteStaffAbsenceCommand request, CancellationToken cancellationToken)
        {
            await _staffAbsenceService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
