using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffZoneSchedule : EntityAuditBase<Guid>
    {
        public string StaffName { get; set; }
        public string ZoneName { get; set; }
        public DateOnly WorkingDate { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid? WorkingSlotId { get; set; }


        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual WorkingSlot WorkingSlot { get; set; }

        public StaffZoneSchedule()
        {
        }

        public StaffZoneSchedule(Guid id, string staffName, string zoneName, DateOnly workingDate, Guid staffId, Guid zoneId, Guid? workingSlotId)
        {
            Id = id;
            StaffName = staffName;
            ZoneName = zoneName;
            WorkingDate = workingDate;
            StaffId = staffId;
            ZoneId = zoneId;
            WorkingSlotId = workingSlotId;
        }
    }
}
