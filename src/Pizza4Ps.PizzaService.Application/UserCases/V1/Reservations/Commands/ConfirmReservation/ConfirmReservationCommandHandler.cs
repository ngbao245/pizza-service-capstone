using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.ConfirmReservation
{
    public class ConfirmReservationCommandHandler : IRequestHandler<ConfirmReservationCommand>
    {
        private readonly IReservationService _reservationService;

        public ConfirmReservationCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task Handle(ConfirmReservationCommand request, CancellationToken cancellationToken)
        {
            await _reservationService.ConfirmAsync(request.ReservationId);
        }
    }
}
