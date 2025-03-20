using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking
{
    public class GetListReservationQuery : PaginatedQuery<PaginatedResultDto<ReservationDto>>
    {
        public DateTime? BookingDate { get; set; }
        public int? GuestCount { get; set; }
        public string? Status { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
