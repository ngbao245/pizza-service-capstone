using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Queries.GetCurrentWorkingSlot
{
    public class GetCurrentWorkingSlotQuery : IRequest<WorkingSlotDto>
    {
    }
}