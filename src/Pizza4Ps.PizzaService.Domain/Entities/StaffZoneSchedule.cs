using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffZoneSchedule : EntityAuditBase<Guid>
    {
        public DateTime Date { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid WorkingSlotId { get; set; }


        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual WorkingSlot WorkingSlot { get; set; }

        public StaffZoneSchedule()
        {
        }

        public StaffZoneSchedule(Guid id, DateTime date, Guid staffId, Guid zoneId, Guid workingSlotId)
        {
            Id = id;
            StaffId = staffId;
            ZoneId = zoneId;
            WorkingSlotId = workingSlotId;
        }
    }
}
