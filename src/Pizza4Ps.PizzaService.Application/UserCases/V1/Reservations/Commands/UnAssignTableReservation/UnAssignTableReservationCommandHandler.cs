using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.UnAssignTableReservation
{
    public class UnAssignTableReservationCommandHandler : IRequestHandler<UnAssignTableReservationCommand>
    {
        private readonly IReservationService _reservationService;

        public UnAssignTableReservationCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public async Task Handle(UnAssignTableReservationCommand request, CancellationToken cancellationToken)
        {
            var result = await _reservationService.UnAssignTableAsync(request.ReservationId, request.TableId);
        }
    }
}
