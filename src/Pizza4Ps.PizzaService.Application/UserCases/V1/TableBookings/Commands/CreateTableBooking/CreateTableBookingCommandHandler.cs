using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.CreateTableBooking
{
	public class CreateTableBookingCommandHandler : IRequestHandler<CreateTableBookingCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly ITableBookingService _tableBookingService;

		public CreateTableBookingCommandHandler(IMapper mapper, ITableBookingService tableBookingService)
		{
			_mapper = mapper;
			_tableBookingService = tableBookingService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateTableBookingCommand request, CancellationToken cancellationToken)
		{
			var result = await _tableBookingService.CreateAsync(
						   request.OnholdTime,
						   request.TableId,
						   request.BookingId);
			return new ResultDto<Guid>
            {
				Id = result
			};
		}
	}
}
