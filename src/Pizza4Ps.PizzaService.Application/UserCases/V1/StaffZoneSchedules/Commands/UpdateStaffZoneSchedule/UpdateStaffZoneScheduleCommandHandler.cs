using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.UpdateStaffZoneSchedule
{
    public class UpdateStaffZoneScheduleCommandHandler : IRequestHandler<UpdateStaffZoneScheduleCommand>
    {
        private readonly IStaffZoneScheduleService _StaffZoneScheduleService;

        public UpdateStaffZoneScheduleCommandHandler(IStaffZoneScheduleService StaffZoneScheduleService)
        {
            _StaffZoneScheduleService = StaffZoneScheduleService;
        }

        public async Task Handle(UpdateStaffZoneScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffZoneScheduleService.UpdateAsync(
                request.Id!.Value,
                request.DayofWeek,
                request.ShiftStart,
                request.ShiftEnd,
                request.Note,
                request.StaffId,
                request.ZoneId,
                request.WorkingTimeId
                );
        }
    }
}
