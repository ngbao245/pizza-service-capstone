using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.WebhookPayOS
{
    public class WebhookPayOsCommandHandler : IRequestHandler<WebhookPayOsCommand, bool>
    {
        private readonly IPaymentService _paymentService;

        public WebhookPayOsCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<bool> Handle(WebhookPayOsCommand request, CancellationToken cancellationToken)
        {
            var result = await _paymentService.ProcessWebhookData(request.WebhookData);
            return result;
        }
    }
}
