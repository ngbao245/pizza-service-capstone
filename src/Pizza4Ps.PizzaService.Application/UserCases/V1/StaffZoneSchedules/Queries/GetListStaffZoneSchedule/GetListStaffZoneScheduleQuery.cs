using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneSchedule
{
    public class GetListStaffZoneScheduleQuery : PaginatedQuery<PaginatedResultDto<StaffZoneScheduleDto>>
    {
        //public int? DayofWeek { get; set; }
        //public TimeOnly? ShiftStart { get; set; }
        //public TimeOnly? ShiftEnd { get; set; }
        //public string? Note { get; set; }
        public DateTime? WorkingDate { get; set; }
        public Guid? StaffId { get; set; }
        public Guid? ZoneId { get; set; }
        public Guid? WorkingSlotId { get; set; }
    }
}