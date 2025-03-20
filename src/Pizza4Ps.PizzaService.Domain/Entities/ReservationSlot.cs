using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ReservationSlot : EntityAuditBase<Guid>
    {
        public TimeSpan StartTime { get; set; } // Ví dụ: 08:00
        public TimeSpan EndTime { get; set; }   // Ví dụ: 10:00
        public int Capacity { get; set; }       // Số khách tối đa của slot

        public ReservationSlot()
        {
            
        }
        public ReservationSlot(TimeSpan startTime, TimeSpan endTime, int capacity)
        {
            Id = Guid.NewGuid();
            StartTime = startTime;
            EndTime = endTime;
            Capacity = capacity;
        }
    }
}

