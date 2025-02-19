using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePaymentLink
{
    public class CreatePaymentLinkCommand : IRequest<string>
    {
        public Guid TableId { get; set; }
    }
}
