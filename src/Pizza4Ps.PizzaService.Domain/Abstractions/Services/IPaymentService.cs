using Net.payOS.Types;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IPaymentService
	{
		Task<string> CreatePaymentQRCode(Guid orderId);
		Task<Guid> CreatePaymentCash(Guid orderId);

        Task<bool> ProcessWebhookData(WebhookType webhookData);
		Task CancelPaymentQRCode(Guid orderId);
        Task<Guid> UpdateAsync(Guid id, decimal amount, PaymentMethodEnum paymentMethod, string status, Guid orderId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
