using Microsoft.EntityFrameworkCore.Metadata;
using Net.payOS;
using Net.payOS.Types;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.DependencyInjection.Options;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class PayOsService : DomainService, IPayOsService
    {
        private readonly VietQRConfig _vietQRConfig;

        public PayOsService(VietQRConfig vietQRConfig)
        {
            _vietQRConfig = vietQRConfig;
        }

        public async Task<string> CreatePaymentLink(float amount, string cancelUrl, string returnUrl)
        {
            PayOS payOS = new PayOS(_vietQRConfig.ClientId, _vietQRConfig.ApiKey, _vietQRConfig.ChecksumKey);
            ItemData item = new ItemData("Pizza hut kkk", 1, 1000);
            List<ItemData> items = new List<ItemData>();
            items.Add(item);
            var orderCode = GenerateOrderCode();
            PaymentData paymentData = new PaymentData(orderCode, 5000, "Thanh toan don hang",
                items, cancelUrl, returnUrl);
            CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
            return createPayment.checkoutUrl;
        }
        long GenerateOrderCode()
        {
            long timestamp = DateTime.UtcNow.Ticks % 1_000_000_000; // 9 số cuối của Ticks
            int randomPart = new Random().Next(100, 999); // Thêm 3 số ngẫu nhiên
            return long.Parse($"{timestamp}{randomPart}");
        }

        public async Task<PaymentLinkInformation> GetPaymentLinkInformation(long orderCode)
        {
            PayOS payOS = new PayOS(_vietQRConfig.ClientId, _vietQRConfig.ApiKey, _vietQRConfig.ChecksumKey);

            PaymentLinkInformation paymentLinkInformation = await payOS.getPaymentLinkInformation(orderCode);
            
            return paymentLinkInformation;
        }
    }
}
