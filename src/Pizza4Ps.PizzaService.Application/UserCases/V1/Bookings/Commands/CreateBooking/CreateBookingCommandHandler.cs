using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking
{
	public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IBookingService _bookingService;

		public CreateBookingCommandHandler(IMapper mapper, IBookingService bookingService)
		{
			_mapper = mapper;
			_bookingService = bookingService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
		{
			var result = await _bookingService.CreateAsync(
				request.BookingDate,
				request.GuestCount,
				request.Status,
				request.CustomerId);
			return new ResultDto<Guid>
			{
				Id = result
			};
		}
	}
}
