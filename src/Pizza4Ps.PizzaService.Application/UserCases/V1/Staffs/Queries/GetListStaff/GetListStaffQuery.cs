using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Queries.GetListStaff
{
    public class GetListStaffQuery : PaginatedQuery<PaginatedResultDto<StaffDto>>
    {
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? StaffType { get; set; }
        public string? Status { get; set; }
    }
}
