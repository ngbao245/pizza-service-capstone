using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.UpdateBooking
{
	public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
	{
		private readonly IReservationService _bookingService;

		public UpdateReservationCommandHandler(IReservationService bookingService)
		{
			_bookingService = bookingService;
		}

		public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
		{
			await _bookingService.ChangeBookingTimeAsync(
				request.Id!.Value,
				request.BookingDate,
				request.GuestCount);
		}
	}
}
