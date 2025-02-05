using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.CreateTableBooking
{
    public class CreateTableBookingCommand : IRequest<ResultDto<Guid>>
	{
        public DateTime OnholdTime { get; set; }
        public Guid TableId { get; set; }
        public Guid BookingId { get; set; }
    }
}
