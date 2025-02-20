using Net.payOS.Types;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IPayOsService : IDomainService
    {
        Task<string> CreatePaymentLink(Guid tableId, string cancelUrl, string returnUrl);
        Task<PaymentLinkInformation> GetPaymentLinkInformation(long orderCode);
    }
}
