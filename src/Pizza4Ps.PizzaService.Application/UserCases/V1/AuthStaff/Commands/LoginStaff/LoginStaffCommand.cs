using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthStaff.Commands.LoginStaff
{
    public class LoginStaffCommand : IRequest<LoginStaffCommandResponse>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
