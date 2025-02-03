using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.UpdateBooking
{
	public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand>
	{
		private readonly IBookingService _bookingService;

		public UpdateBookingCommandHandler(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		public async Task Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
		{
			var result = await _bookingService.UpdateAsync(
				request.Id!.Value,
				request.BookingDate,
				request.GuestCount,
				request.Status,
				request.CustomerId);
		}
	}
}
