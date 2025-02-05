using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<ResultDto<Guid>>
	{
        public DateTime BookingDate { get; set; }
        public int GuestCount { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
    }
}
