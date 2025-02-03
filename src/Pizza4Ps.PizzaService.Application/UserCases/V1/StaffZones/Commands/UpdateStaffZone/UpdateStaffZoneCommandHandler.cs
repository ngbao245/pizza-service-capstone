using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.UpdateStaffZone
{
    public class UpdateStaffZoneCommandHandler : IRequestHandler<UpdateStaffZoneCommand>
    {
        private readonly IStaffZoneService _StaffZoneService;

        public UpdateStaffZoneCommandHandler(IStaffZoneService StaffZoneService)
        {
            _StaffZoneService = StaffZoneService;
        }

        public async Task Handle(UpdateStaffZoneCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffZoneService.UpdateAsync(
                request.Id!.Value,
                request.ShiftStart,
                request.ShiftEnd,
                request.Note,
                request.StaffId,
                request.ZoneId
                );
        }
    }
}
