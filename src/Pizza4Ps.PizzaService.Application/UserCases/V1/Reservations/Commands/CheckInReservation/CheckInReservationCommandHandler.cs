using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CheckInReservation
{
    public class CheckInReservationCommandHandler : IRequestHandler<CheckInReservationCommand, bool>
    {
        private readonly IReservationService _reservationService;

        public CheckInReservationCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<bool> Handle(CheckInReservationCommand request, CancellationToken cancellationToken)
        {
            return await _reservationService.CheckInAsync(request.ReservationId);
        }
    }
}
