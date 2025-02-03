using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetStaffZoneById
{
    public class GetStaffZoneByIdQuery : IRequest<StaffZoneDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
