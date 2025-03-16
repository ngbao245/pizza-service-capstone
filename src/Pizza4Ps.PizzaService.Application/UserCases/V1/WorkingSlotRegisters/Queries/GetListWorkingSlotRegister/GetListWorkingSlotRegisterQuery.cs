using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Queries.GetListWorkingSlotRegister
{
    public class GetListWorkingSlotRegisterQuery : PaginatedQuery<PaginatedResultDto<WorkingSlotRegisterDto>>
    {
        public DateOnly? WorkingDate { get; set; }
        public string? Status { get; set; }
        public Guid? StaffId { get; set; }
        public Guid? WorkingSlotId { get; set; }
    }
}