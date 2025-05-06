using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.ReopenToRegisterWorkshop
{
    public class ReopenToRegisterWorkshopCommand : IRequest
    {
        public Guid? WorkshopId { get; set; }

        public DateTime NewEndRegisterDate { get; set; }
    }
}
