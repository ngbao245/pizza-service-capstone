using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffZone : EntityAuditBase<Guid>
    {
        public string? Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }

        public StaffZone()
        {
        }

        public StaffZone(Guid id, string note, Guid staffId, Guid zoneId)
        {
            Id = id;
            Note = note;
            StaffId = staffId;
            ZoneId = zoneId;
        }

        public void UpdateStaffZone(string note, Guid staffId, Guid zoneId)
        {
            Note = note;
            StaffId = staffId;
            ZoneId = zoneId;
        }

        public void UpdateNote(string note)
        {
            Note = note;
        }
    }
}