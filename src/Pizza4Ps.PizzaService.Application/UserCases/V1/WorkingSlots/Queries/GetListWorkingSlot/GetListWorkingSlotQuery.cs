using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Queries.GetListWorkingSlot
{
    public class GetListWorkingSlotQuery : PaginatedQuery<PaginatedResultDto<WorkingSlotDto>>
    {
        public TimeSpan? ShiftStart { get; set; } // Ví dụ: 08:00
        public TimeSpan? ShiftEnd { get; set; }   // Ví dụ: 12:00
        public Guid? DayId { get; set; }
        public Guid? ShiftId { get; set; }
    }
}

