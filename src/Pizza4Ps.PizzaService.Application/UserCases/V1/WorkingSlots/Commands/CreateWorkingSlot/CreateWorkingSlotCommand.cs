using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Commands.CreateWorkingSlot
{
    public class CreateWorkingSlotCommand : IRequest<ResultDto<Guid>>
    {
        public TimeSpan ShiftStart { get; set; } // Ví dụ: 08:00
        public TimeSpan ShiftEnd { get; set; }   // Ví dụ: 12:00
        public int Capacity { get; set; }
        public Guid DayId { get; set; }
        public Guid ShiftId { get; set; }
    }
}