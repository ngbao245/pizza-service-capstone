using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.AssignTableReservation
{
    public class AssignTableReservationCommandHandler : IRequestHandler<AssignTableReservationCommand, bool>
    {
        private readonly IReservationService _reservationService;

        public AssignTableReservationCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<bool> Handle(AssignTableReservationCommand request, CancellationToken cancellationToken)
        {
            var result = await _reservationService.AssignTableAsync(request.ReservationId, request.TableId);
            return result;
        }
    }
}
