using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.BookingSlots.Commands.CreateBookingSlot
{
    public class CreateBookingSlotCommand : IRequest<ResultDto<Guid>>
    {
        public TimeSpan StartTime { get; set; } // Ví dụ: 08:00:00
        public TimeSpan EndTime { get; set; }   // Ví dụ: 10:00:00
        public int Capacity { get; set; }       // Số khách tối đa của slot
    }
}
