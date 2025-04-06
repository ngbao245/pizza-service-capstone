using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.CreateStaffZone
{
    public class CreateStaffZoneCommand : IRequest<ResultDto<Guid>>
    {
        public string? Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
    }
}
