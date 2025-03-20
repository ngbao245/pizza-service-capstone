using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Shifts.Queries.GetShiftById
{
    public class GetShiftByIdQuery : IRequest<ShiftDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}

