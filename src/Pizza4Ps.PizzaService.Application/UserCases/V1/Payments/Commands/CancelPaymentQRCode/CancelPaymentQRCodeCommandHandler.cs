using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CancelPaymentQRCode
{
    public class CancelPaymentQRCodeCommandHandler : IRequestHandler<CancelPaymentQRCodeCommand>
    {
        private readonly IPaymentService _paymentService;

        public CancelPaymentQRCodeCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task Handle(CancelPaymentQRCodeCommand request, CancellationToken cancellationToken)
        {
            await _paymentService.CancelPaymentQRCode(request.OrderId);
        }
    }
}
