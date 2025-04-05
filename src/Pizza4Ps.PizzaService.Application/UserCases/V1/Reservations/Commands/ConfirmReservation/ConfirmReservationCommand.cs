using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.ConfirmReservation
{
    public class ConfirmReservationCommand : IRequest
    {
        public Guid ReservationId { get; set; }
    }
}
