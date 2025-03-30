using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.AutoAssignZone
{
    public class AutoAssignZoneCommand : IRequest
    {
        public DateOnly WorkingDate { get; set; }
    }
}
