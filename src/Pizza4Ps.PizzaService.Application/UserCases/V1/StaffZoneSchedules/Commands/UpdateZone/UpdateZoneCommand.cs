using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.UpdateZone
{
    public class UpdateZoneCommand : IRequest
    {
        public Guid? Id { get; set; }
        public Guid ZoneId { get; set; }
    }
}
