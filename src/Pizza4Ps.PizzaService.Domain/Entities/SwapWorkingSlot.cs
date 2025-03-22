using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class SwapWorkingSlot : EntityAuditBase<Guid>
    {
        public SwapWorkingSlotStatusEnum Status { get; set; }
        public Guid EmployeeFromId { get; set; }
        public Guid EmployeeToId { get; set; }
        public Guid ShiftScheduleFromId { get; set; }
        public Guid ShiftScheduleToId { get; set; }

        public virtual Staff StaffFrom { get; set; }
        public virtual Staff StaffTo { get; set; }
        public virtual WorkingSlot WorkingSlotFrom { get; set; }
        public virtual WorkingSlot WorkingSlotTo { get; set; }

        public SwapWorkingSlot()
        {
        }

        public SwapWorkingSlot(SwapWorkingSlotStatusEnum status, Guid employeeFromId, Guid employeeToId, Guid shiftScheduleFromId, Guid shiftScheduleToId)
        {
            Status = status;
            EmployeeFromId = employeeFromId;
            EmployeeToId = employeeToId;
            ShiftScheduleFromId = shiftScheduleFromId;
            ShiftScheduleToId = shiftScheduleToId;
        }
    }
}
