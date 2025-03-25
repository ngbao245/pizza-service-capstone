using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class WorkingSlotDto
    {
        public Guid Id { get; set; }
        public TimeSpan ShiftStart { get; set; } // Ví dụ: 08:00
        public TimeSpan ShiftEnd { get; set; }   // Ví dụ: 12:00
        public int Capacity { get; set; }
        public Guid DayId { get; set; }
        public Guid ShiftId { get; set; }

        public virtual Day Day { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
