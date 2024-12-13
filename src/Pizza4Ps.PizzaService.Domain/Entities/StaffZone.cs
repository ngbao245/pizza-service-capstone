using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffZone : EntityAuditBase<Guid>
    {
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }


        public DateOnly WorkDate { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string Note { get; set; }


        public StaffZone()
        {
        }

        public StaffZone(Guid id ,Guid staffId, Guid zoneId, DateOnly workDate, TimeOnly shiftStart, TimeOnly shiftEnd, string note)
        {
            Id = id;
            StaffId = staffId;
            ZoneId = zoneId;
            WorkDate = workDate;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Note = note;
        }
    }
}