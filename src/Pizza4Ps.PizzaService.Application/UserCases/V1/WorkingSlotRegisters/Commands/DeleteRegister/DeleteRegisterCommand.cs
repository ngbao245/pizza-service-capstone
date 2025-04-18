using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.DeleteRegister
{
    public class DeleteRegisterCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}

