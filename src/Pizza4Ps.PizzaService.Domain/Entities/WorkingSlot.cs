using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class WorkingSlot : EntityAuditBase<Guid>
    {
        public Guid Id { get; set; }
        public string ShiftName { get; set; }
        public string DayName { get; set; }
        public TimeSpan ShiftStart { get; set; } // Ví dụ: 08:00
        public TimeSpan ShiftEnd { get; set; }   // Ví dụ: 12:00
        public int Capacity { get; set; }
        public Guid DayId { get; set; }
        public Guid ShiftId { get; set; }

        public virtual Day Day { get; set; }
        public virtual Shift Shift { get; set; }

        public WorkingSlot()
        {
        }

        public WorkingSlot(Guid id, string shiftName, string dayName, TimeSpan shiftStart, TimeSpan shiftEnd, int capacity, Guid dayId, Guid shiftId)
        {
            Id = id;
            ShiftName = shiftName;
            DayName = dayName;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Capacity = capacity;
            DayId = dayId;
            ShiftId = shiftId;
        }
    }
}
