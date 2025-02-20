using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePaymentQRCode
{
    public class CreatePaymentQRCodeCommandHandler : IRequestHandler<CreatePaymentQRCodeCommand, string>
    {
        private readonly IPaymentService _paymentService;

        public CreatePaymentQRCodeCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<string> Handle(CreatePaymentQRCodeCommand request, CancellationToken cancellationToken)
        {
            var result = await _paymentService.CreatePaymentQRCode(request.OrderId);
            return result;
        }
    }
}
