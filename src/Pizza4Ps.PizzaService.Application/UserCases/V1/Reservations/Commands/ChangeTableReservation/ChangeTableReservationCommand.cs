using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.ChangeTableReservation
{
    public class ChangeTableReservationCommand : IRequest
    {
        public Guid ReservationId { get; set; }

        public Guid NewTableId { get; set; }
    }
}
