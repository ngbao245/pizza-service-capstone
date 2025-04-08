namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ReservationSlotDto
    {
        public TimeSpan StartTime { get; set; } // Ví dụ: 08:00
        public TimeSpan EndTime { get; set; }   // Ví dụ: 10:00
        public int Capacity { get; set; }       // Số khách tối đa của slot
    } 
}
