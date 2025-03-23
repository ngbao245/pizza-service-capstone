using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.RestoreBooking
{
	public class RestoreReservationCommandHandler
	{
		private readonly IReservationService _bookingService;

		public RestoreReservationCommandHandler(IReservationService bookingService)
		{
			_bookingService = bookingService;
		}

		public async Task Handle(RestoreReservationCommand request, CancellationToken cancellationToken)
		{
			await _bookingService.RestoreAsync(request.Ids);
		}
	}
}
