using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CancelWorkshop
{
    public class CancelWorkshopCommand : IRequest
    {
        public Guid WorkshopId { get; set; }
    }
}
