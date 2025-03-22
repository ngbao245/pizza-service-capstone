using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Queries.GetWorkingSlotRegisterById
{
    public class GetWorkingSlotRegisterByIdQuery : IRequest<WorkingSlotRegisterDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
