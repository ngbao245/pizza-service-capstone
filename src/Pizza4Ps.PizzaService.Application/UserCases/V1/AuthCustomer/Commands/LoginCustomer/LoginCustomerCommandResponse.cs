namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.LoginCustomer
{
    public class LoginCustomerCommandResponse
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
