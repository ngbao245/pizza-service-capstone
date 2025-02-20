using Net.payOS.Types;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IPayOsService : IDomainService
    {
        Task<CreatePaymentResult> CreatePaymentLink(long orderCode, decimal amount, string description);
        Task<PaymentLinkInformation> GetPaymentLinkInformation(long orderCode);
        WebhookData VerifyPaymentWebhookData(object webhookData);
    }
}
