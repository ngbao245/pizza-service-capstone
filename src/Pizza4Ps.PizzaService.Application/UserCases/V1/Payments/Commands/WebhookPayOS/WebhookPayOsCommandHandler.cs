using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.WebhookPayOS
{
    public class WebhookPayOsCommandHandler : IRequestHandler<WebhookPayOsCommand>
    {
        private readonly IPaymentService _paymentService;

        public WebhookPayOsCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task Handle(WebhookPayOsCommand request, CancellationToken cancellationToken)
        {
            await _paymentService.ProcessWebhookData(request.WebhookData);
        }
    }
}
