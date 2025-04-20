using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Queries.GetListStaffAbsence
{
    public class GetListStaffAbsenceQuery : PaginatedQuery<PaginatedResultDto<StaffAbsenceDto>>
    {
        public Guid? StaffId { get; set; }
        public Guid? WorkingSlotId { get; set; }
        public DateOnly? AbsentDate { get; set; }
    }
}
