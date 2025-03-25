namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthStaff.Commands.LoginStaff
{
    public class LoginStaffCommandResponse
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
