using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Queries.CheckReservation
{
    public class CheckReservationQuery : PaginatedQuery<PaginatedResultDto<ReservationDto>>
    {
        public string? PhoneNumber { get; set; }
    }
}
