using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Commands.RestoreStaffAbsence
{
    public class RestoreStaffAbsenceCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}