using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.UpdateStaffZone
{
    public class UpdateStaffZoneCommand : IRequest
    {
        public Guid? Id { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string? Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
    }
}
