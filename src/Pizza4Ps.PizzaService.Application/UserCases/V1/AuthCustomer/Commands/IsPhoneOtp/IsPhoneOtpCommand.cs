using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.IsPhoneOtp
{
    public class IsPhoneOtpCommand : IRequest<bool>
    {
        public string PhoneNumber { get; set; }
        public string Otp { get; set; }
    }
}
