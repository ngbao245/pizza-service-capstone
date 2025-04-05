using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CancelReservation
{
    public class CancelReservationCommand : IRequest
    {
        public Guid ReservationId { get; set; }
    }
}
