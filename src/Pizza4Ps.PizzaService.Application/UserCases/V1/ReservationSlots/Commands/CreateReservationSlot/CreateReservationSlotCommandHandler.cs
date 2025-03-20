using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.BookingSlots.Commands.CreateBookingSlot
{
    public class CreateReservationSlotCommandHandler : IRequestHandler<CreateReservationSlotCommand, ResultDto<Guid>>
    {
        private readonly IReservationSlotService _bookingSlotService;

        public CreateReservationSlotCommandHandler(IReservationSlotService bookingSlotService)
        {
            _bookingSlotService = bookingSlotService;
        }
        public async Task<ResultDto<Guid>> Handle(CreateReservationSlotCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookingSlotService.CreateAsync(request.StartTime, request.EndTime, request.Capacity);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
