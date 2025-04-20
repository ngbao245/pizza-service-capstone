using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Queries.GetStaffAbsenceById
{
    public class GetStaffAbsenceByIdQuery : IRequest<StaffAbsenceDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
