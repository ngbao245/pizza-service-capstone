using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class WorkingSlotRegister : EntityAuditBase<Guid>
    {
        public DateTime WorkingDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public WorkingSlotRegisterStatusEnum Status { get; set; }
        public Guid StaffId { get; set; }
        public Guid WorkingSlotId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual WorkingSlot WorkingSlot { get; set; }

        public WorkingSlotRegister()
        {
        }

        public WorkingSlotRegister(DateTime workingDate, DateTime registerDate, WorkingSlotRegisterStatusEnum status, Guid staffId, Guid workingSlotId)
        {
            WorkingDate = workingDate;
            RegisterDate = registerDate;
            Status = status;
            StaffId = staffId;
            WorkingSlotId = workingSlotId;
        }

        public void setApproved()
        {
            if (Status == WorkingSlotRegisterStatusEnum.Approved)
                throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_ALREADY_APPROVED);
            Status = WorkingSlotRegisterStatusEnum.Approved;
        }

        public void setRejected()
        {
            if (Status == WorkingSlotRegisterStatusEnum.Rejected)
                throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_ALREADY_REJECTED);
            Status = WorkingSlotRegisterStatusEnum.Rejected;
        }
    }
}
