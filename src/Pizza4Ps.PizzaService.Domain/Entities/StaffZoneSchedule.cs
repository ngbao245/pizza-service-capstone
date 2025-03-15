using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffZoneSchedule : EntityAuditBase<Guid>
    {
        public DateOnly WorkingDate { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid WorkingSlotId { get; set; }


        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual WorkingSlot WorkingSlot { get; set; }

        public StaffZoneSchedule()
        {
        }

        public StaffZoneSchedule(Guid id, DateOnly workingDate, Guid staffId, Guid zoneId, Guid workingSlotId)
        {
            Id = id;
            WorkingDate = workingDate;
            StaffId = staffId;
            ZoneId = zoneId;
            WorkingSlotId = workingSlotId;
        }
    }
}
