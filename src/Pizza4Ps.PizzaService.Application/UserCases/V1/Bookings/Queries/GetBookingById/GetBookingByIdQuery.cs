using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQuery : IRequest<BookingDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}

