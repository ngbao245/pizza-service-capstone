using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.WebhookPayOS
{
    public class WebhookPayOsCommand : IRequest
    {
        public object WebhookData { get; set; }
    }
}
