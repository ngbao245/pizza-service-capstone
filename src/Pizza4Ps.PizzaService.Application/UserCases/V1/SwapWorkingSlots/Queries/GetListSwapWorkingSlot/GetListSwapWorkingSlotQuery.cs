using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Queries.GetListSwapWorkingSlot
{
    public class GetListSwapWorkingSlotQuery : PaginatedQuery<PaginatedResultDto<SwapWorkingSlotDto>>
    {
        public DateTime? RequestDate { get; set; }
        public string? Status { get; set; }
        public Guid? EmployeeFromId { get; set; }
        public Guid? EmployeeToId { get; set; }
        public Guid? WorkingSlotFromId { get; set; }
        public Guid? WorkingSlotToId { get; set; }
    }
}
