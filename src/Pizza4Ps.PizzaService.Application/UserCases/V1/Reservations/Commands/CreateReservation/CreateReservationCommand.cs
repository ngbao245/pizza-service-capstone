using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking
{
    public class CreateReservationCommand : IRequest<ResultDto<Guid>>
	{
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneOtp { get; set; }
        public DateTime BookingTime { get; set; } // Giờ khách hàng chọn đến
        public int NumberOfPeople { get; set; }
    }
}
