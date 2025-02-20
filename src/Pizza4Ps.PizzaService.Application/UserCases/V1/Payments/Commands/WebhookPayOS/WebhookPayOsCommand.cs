using MediatR;
using Net.payOS.Types;
using Pizza4Ps.PizzaService.Application.DTOs.WebhookPayOsDto;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.WebhookPayOS
{
    public class WebhookPayOsCommand : IRequest<bool>
    {
        public WebhookType WebhookDto { get; set; }
    }
}
