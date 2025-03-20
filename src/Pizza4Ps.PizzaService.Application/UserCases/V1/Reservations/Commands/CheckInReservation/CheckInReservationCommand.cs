using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CheckInReservation
{
    public class CheckInReservationCommand : IRequest<bool>
    {
        public Guid ReservationId { get; set; }
    }
}