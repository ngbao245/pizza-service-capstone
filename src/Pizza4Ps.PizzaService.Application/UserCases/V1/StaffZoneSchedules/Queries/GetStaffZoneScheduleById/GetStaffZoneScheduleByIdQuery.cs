using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetStaffZoneScheduleById
{
    public class GetStaffZoneScheduleByIdQuery : IRequest<StaffZoneScheduleDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
