using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CreateReservationByAdmin
{
    public class CreateReservationByAdminCommand : IRequest<ResultDto<Guid>>
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BookingTime { get; set; } // Giờ khách hàng chọn đến
        public int NumberOfPeople { get; set; }
    }
}
