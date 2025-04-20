using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Commands.DeleteStaffAbsence
{
    public class DeleteStaffAbsenceCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}
