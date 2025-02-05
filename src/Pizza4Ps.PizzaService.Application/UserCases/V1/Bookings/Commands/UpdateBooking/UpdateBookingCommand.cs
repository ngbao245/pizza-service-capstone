using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest
	{
		public Guid? Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int GuestCount { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
    }
}

