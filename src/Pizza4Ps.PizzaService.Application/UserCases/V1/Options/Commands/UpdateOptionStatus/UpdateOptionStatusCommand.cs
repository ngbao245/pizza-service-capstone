using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.UpdateOptionStatus
{
    public class UpdateOptionStatusCommand : IRequest
    {
        public Guid? Id { get; set; }

        public string OptionStatus { get; set; }
    }
}
