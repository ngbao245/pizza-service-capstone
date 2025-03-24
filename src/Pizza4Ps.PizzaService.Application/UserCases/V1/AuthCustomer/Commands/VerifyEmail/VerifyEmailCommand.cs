using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.VerifyEmail
{
    public class VerifyEmailCommand : IRequest
    {
        public Guid? CustomerId { get; set; }
        public string Code { get; set; }
    }
}
