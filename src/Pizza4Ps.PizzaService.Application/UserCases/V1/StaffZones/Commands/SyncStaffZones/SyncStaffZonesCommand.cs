using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.SyncStaffZones
{
    public class SyncStaffZonesCommand : IRequest
    {
        public DateOnly workingDate { get; set; }
        public Guid workingSlotId { get; set; }
    }
}
