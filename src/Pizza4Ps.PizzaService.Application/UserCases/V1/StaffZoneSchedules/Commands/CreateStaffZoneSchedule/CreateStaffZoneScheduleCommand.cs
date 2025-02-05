using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.CreateStaffZoneSchedule
{
    public class CreateStaffZoneScheduleCommand : IRequest<ResultDto<Guid>>
    {
        public int DayofWeek { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid WorkingTimeId { get; set; }
    }
}
