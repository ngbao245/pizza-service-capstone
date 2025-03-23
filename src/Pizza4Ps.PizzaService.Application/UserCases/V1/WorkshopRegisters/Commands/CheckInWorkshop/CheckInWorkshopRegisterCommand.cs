using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.CheckInWorkshop
{
    public class CheckInWorkshopRegisterCommand : IRequest
    {
        public Guid WorkshopRegisterId { get; set; }
    }
}
