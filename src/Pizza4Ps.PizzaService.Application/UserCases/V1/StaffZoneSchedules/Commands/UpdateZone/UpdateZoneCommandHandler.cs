using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.UpdateZone
{
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand>
    {
        private readonly IStaffZoneScheduleService _StaffZoneScheduleService;

        public UpdateZoneCommandHandler(IStaffZoneScheduleService StaffZoneScheduleService)
        {
            _StaffZoneScheduleService = StaffZoneScheduleService;
        }

        public async Task Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffZoneScheduleService.UpdateZoneAsync(request.Id.Value, request.ZoneId);
        }
    }
}
