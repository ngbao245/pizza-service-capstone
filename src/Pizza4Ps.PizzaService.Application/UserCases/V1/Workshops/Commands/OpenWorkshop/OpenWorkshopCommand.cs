using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.OpenWorkshop
{
    public class OpenWorkshopCommand : IRequest
    {
        public Guid? WorkshopId { get; set; }
    }
}
