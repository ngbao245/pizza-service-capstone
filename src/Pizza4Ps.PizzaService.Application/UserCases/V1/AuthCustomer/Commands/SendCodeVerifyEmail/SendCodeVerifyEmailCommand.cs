using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.SendCodeVerifyEmail
{
    public class SendCodeVerifyEmailCommand : IRequest
    {
        public Guid? CustomerId { get; set; }
    }
}
