using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<ResultDto<Guid>>
	{
        public Guid? CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BookingTime { get; set; } // Giờ khách hàng chọn đến
        public int NumberOfPeople { get; set; }
    }
}
