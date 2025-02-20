using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.WebhookPayOS
{
    public class WebhookPayOsCommand : IRequest<bool>
    {
        public object WebhookData { get; set; }
    }
}
