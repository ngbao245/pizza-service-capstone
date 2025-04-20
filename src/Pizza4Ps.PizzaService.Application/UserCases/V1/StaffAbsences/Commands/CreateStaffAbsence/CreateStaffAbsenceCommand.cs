using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Commands.CreateStaffAbsence
{
    public class CreateStaffAbsenceCommand : IRequest<ResultDto<Guid>>
    {
        public Guid StaffId { get; set; }
        public Guid WorkingSlotId { get; set; }
        public DateOnly AbsentDate { get; set; }
    }
}
