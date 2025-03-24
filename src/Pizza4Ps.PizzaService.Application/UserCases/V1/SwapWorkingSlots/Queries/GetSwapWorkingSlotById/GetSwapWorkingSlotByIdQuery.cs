using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Queries.GetSwapWorkingSlotById
{
    public class GetSwapWorkingSlotByIdQuery : IRequest<SwapWorkingSlotDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
