using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffAbsence : EntityAuditBase<Guid>
    {
        public Guid StaffId { get; set; }
        public Guid WorkingSlotId { get; set; }
        public DateOnly AbsentDate { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual WorkingSlot WorkingSlot { get; set; }

        public StaffAbsence() { }

        public StaffAbsence(Guid id, Guid staffId, Guid workingSlotId, DateOnly absentDate)
        {
            Id = id;
            StaffId = staffId;
            WorkingSlotId = workingSlotId;
            AbsentDate = absentDate;
        }
    }
}
