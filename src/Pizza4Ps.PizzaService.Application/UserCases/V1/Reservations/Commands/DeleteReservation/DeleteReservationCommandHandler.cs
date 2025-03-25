using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.DeleteBooking
{
	internal class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
	{
		private readonly IReservationService _bookingService;

		public DeleteReservationCommandHandler(IReservationService bookingService)
		{
			_bookingService = bookingService;
		}

		public async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
		{
			await _bookingService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
