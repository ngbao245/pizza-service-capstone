using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CheckInReservation
{
    public class CheckInReservationCommandHandler : IRequestHandler<CheckInReservationCommand>
    {
        private readonly IReservationService _reservationService;

        public CheckInReservationCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task Handle(CheckInReservationCommand request, CancellationToken cancellationToken)
        {
            await _reservationService.CheckInAsync(request.ReservationId);
        }
    }
}
