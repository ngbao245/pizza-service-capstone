using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.SendCodeVerifyPhone
{
    public class SendOtpVerifyPhoneCommand : IRequest
    {
        public string PhoneNumber { get; set; }
    }
}
