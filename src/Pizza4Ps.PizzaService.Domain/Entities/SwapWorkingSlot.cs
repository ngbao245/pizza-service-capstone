using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class SwapWorkingSlot : EntityAuditBase<Guid>
    {
        public DateTime RequestDate { get; set; }
        public SwapWorkingSlotStatusEnum Status { get; set; }
        public DateOnly WorkingDateFrom { get; set; }
        public string EmployeeFromName { get; set; }
        public Guid EmployeeFromId { get; set; }
        public Guid WorkingSlotFromId { get; set; }
        public DateOnly WorkingDateTo { get; set; }
        public string EmployeeToName { get; set; }
        public Guid EmployeeToId { get; set; }
        public Guid WorkingSlotToId { get; set; }

        public virtual Staff StaffFrom { get; set; }
        public virtual Staff StaffTo { get; set; }
        public virtual WorkingSlot WorkingSlotFrom { get; set; }
        public virtual WorkingSlot WorkingSlotTo { get; set; }

        public SwapWorkingSlot()
        {
        }

        public SwapWorkingSlot(Guid id, DateOnly workingDateFrom, string employeeFromName, Guid employeeFromId, Guid workingSlotFromId,
                                        DateOnly workingDateTo, string employeeToName, Guid employeeToId, Guid workingSlotToId)
        {
            Id = id;
            RequestDate = DateTime.Now;
            Status = SwapWorkingSlotStatusEnum.PendingStaffAgree;
            WorkingDateFrom = workingDateFrom;
            EmployeeFromName = employeeFromName;
            EmployeeFromId = employeeFromId;
            WorkingSlotFromId = workingSlotFromId;
            WorkingSlotToId = workingSlotToId;
            EmployeeToName = employeeToName;
            EmployeeToId = employeeToId;
            WorkingSlotToId = workingSlotToId;
        }

        public void setPendingApprove()
        {
            if (Status == SwapWorkingSlotStatusEnum.PendingManagerApprove)
                throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_ALREADY_PENDING_APPROVE);
            Status = SwapWorkingSlotStatusEnum.PendingManagerApprove;
        }

        public void setApproved()
        {
            if (Status == SwapWorkingSlotStatusEnum.Approved)
                throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_ALREADY_APPROVED);
            Status = SwapWorkingSlotStatusEnum.Approved;
        }

        public void setRejected()
        {
            if (Status == SwapWorkingSlotStatusEnum.Rejected)
                throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_ALREADY_REJECTED);
            Status = SwapWorkingSlotStatusEnum.Rejected;
        }
    }
}
