using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Days.Queries.GetDayById
{
    public class GetDayByIdQuery : IRequest<DayDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
