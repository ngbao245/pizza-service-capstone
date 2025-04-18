using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.UnAssignTableReservation
{
    public class UnAssignTableReservationCommand : IRequest
    {
        public Guid ReservationId { get; set; }
        public List<Guid> TableId { get; set; }
    }
}
