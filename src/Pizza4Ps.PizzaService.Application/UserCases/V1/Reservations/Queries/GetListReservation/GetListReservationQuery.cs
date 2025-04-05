using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking
{
    public class GetListReservationQuery : PaginatedQuery<PaginatedResultDto<ReservationDto>>
    {
        public Guid? CustomerCode { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? BookingTime { get; set; }
        public string? BookingStatus { get; set; }
    }
}
