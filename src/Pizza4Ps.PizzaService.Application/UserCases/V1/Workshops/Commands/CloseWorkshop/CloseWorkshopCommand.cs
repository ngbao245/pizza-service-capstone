using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CloseWorkshop
{
    public class CloseWorkshopCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
