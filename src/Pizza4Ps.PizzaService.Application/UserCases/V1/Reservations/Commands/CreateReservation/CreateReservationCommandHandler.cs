using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking
{
	public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IReservationService _bookingService;

		public CreateReservationCommandHandler(IMapper mapper, IReservationService bookingService)
		{
			_mapper = mapper;
			_bookingService = bookingService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
			var result = await _bookingService.CreateAsync(
				customerCode: request.CustomerCode,
				customerName: request.CustomerName,
				phoneNumber: request.PhoneNumber,
				bookingTime: request.BookingTime, 
				numberOfPeople: request.NumberOfPeople);
			return new ResultDto<Guid>
			{
				Id = result
			};
		}
	}
}
