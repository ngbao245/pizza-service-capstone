using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.UpdateTableBooking
{
	public class UpdateTableBookingCommandHandler : IRequestHandler<UpdateTableBookingCommand>
	{
		private readonly ITableBookingService _tableBookingService;

		public UpdateTableBookingCommandHandler(ITableBookingService tableBookingService)
		{
			_tableBookingService = tableBookingService;
		}

		public async Task Handle(UpdateTableBookingCommand request, CancellationToken cancellationToken)
		{
			var result = await _tableBookingService.UpdateAsync(
				request.Id!.Value,
				request.OnholdTime,
				request.TableId,
				request.BookingId);
		}
	}
}
