using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.SyncStaffZones
{
    public class SyncStaffZonesCommand : IRequest
    {
        public Guid workingSlotId { get; set; }
    }
}
