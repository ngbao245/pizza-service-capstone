using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.ConfirmReservation;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CancelReservation
{
    public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand>
    {
        private readonly IReservationService _reservationService;

        public CancelReservationCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            await _reservationService.CancelAsync(request.ReservationId);
        }
    }
}
