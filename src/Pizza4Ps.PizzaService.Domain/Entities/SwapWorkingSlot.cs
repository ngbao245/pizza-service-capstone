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
        public Guid EmployeeFromId { get; set; }
        public Guid EmployeeToId { get; set; }
        public Guid WorkingSlotFromId { get; set; }
        public Guid WorkingSlotToId { get; set; }

        public virtual Staff StaffFrom { get; set; }
        public virtual Staff StaffTo { get; set; }
        public virtual WorkingSlot WorkingSlotFrom { get; set; }
        public virtual WorkingSlot WorkingSlotTo { get; set; }

        public SwapWorkingSlot()
        {
        }

        public SwapWorkingSlot(Guid id, Guid employeeFromId, Guid employeeToId, Guid workingSlotFromId, Guid workingSlotToId)
        {
            Id = id;
            RequestDate = DateTime.Now;
            Status = SwapWorkingSlotStatusEnum.PendingStaffAgree;
            EmployeeFromId = employeeFromId;
            EmployeeToId = employeeToId;
            WorkingSlotFromId = workingSlotFromId;
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
