using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePaymentQRCode
{
    public class CreatePaymentQRCodeCommand : IRequest<string>
    {
        public Guid OrderId { get; set; }
    }
}
