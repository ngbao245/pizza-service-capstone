using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CancelPaymentQRCode
{
    public class CancelPaymentQRCodeCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
