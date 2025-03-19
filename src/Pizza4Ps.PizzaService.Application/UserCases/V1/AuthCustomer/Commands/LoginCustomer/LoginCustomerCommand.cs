using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.LoginCustomer
{
    public class LoginCustomerCommand : IRequest<LoginCustomerCommandResponse>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
