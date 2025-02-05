using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.UpdateTableBooking
{
    public class UpdateTableBookingCommand : IRequest
	{
		public Guid? Id { get; set; }
        public DateTime OnholdTime { get; set; }
        public Guid TableId { get; set; }
        public Guid BookingId { get; set; }
    }
}
