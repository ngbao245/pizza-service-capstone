using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.UpdateOptionItemStatus
{
    public class UpdateOptionItemStatusCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string OptionItemStatus { get; set; }
    }
}
