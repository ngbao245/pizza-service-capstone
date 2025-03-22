using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Queries.GetWorkingSlotById
{
    public class GetWorkingSlotByIdQuery : IRequest<WorkingSlotDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}

