using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.RegisterWorkingSlot
{
    public class RegisterWorkingSlotCommand : IRequest<ResultDto<Guid>>
    {
        public Guid StaffId { get; set; }
        public Guid WorkingSlotId { get; set; }
    }
}
