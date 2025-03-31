namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class StaffZoneScheduleDto
    {
        public Guid Id { get; set; }
        public string StaffName { get; set; }
        public string ZoneName { get; set; }
        public DateOnly WorkingDate { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid? WorkingSlotId { get; set; }

        public virtual StaffDto Staff { get; set; }
        public virtual ZoneDto Zone { get; set; }
        public virtual WorkingSlotDto WorkingSlot { get; set; }
    }
}
