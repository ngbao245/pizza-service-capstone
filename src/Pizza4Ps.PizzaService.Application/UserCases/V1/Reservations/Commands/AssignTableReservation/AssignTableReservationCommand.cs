using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.AssignTableReservation
{
    public class AssignTableReservationCommand : IRequest<bool>
    {
        public Guid ReservationId { get; set; }
        public Guid TableId { get; set; }
    }
}
