using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.AssignTableWorkshopRegister
{
    public class AssignTableWorkshopRegisterCommand : IRequest
    {
        public Guid WorkshopRegisterId { get; set; }
        public Guid TableId { get; set; }
    }
}
