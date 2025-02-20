using Net.payOS;
using Net.payOS.Types;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.DependencyInjection.Options;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class PayOsService : DomainService, IPayOsService
    {
        private readonly VietQRConfig _vietQRConfig;
        private readonly ITableRepository _tableRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public PayOsService(VietQRConfig vietQRConfig,
            IOrderRepository orderRepository,
            ITableRepository tableRepository,
            IOrderItemRepository orderItemRepository)
        {
            _vietQRConfig = vietQRConfig;
            _tableRepository = tableRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<CreatePaymentResult> CreatePaymentLink(long orderCode, decimal amount, string description)
        {
            //var order = await _orderRepository.GetSingleByIdAsync(orderId, "OrderItems");
            //if (order == null) 
            //    throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            //if (order.Status != Enums.OrderStatusEnum.CheckedOut)
            //    throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_CANNOT_PAY);
            var items = new List<ItemData>
            {
                new ItemData("Thanh toán đơn hàng", 1, (int)amount)
            };
            PayOS payOS = new PayOS(_vietQRConfig.ClientId, _vietQRConfig.ApiKey, _vietQRConfig.ChecksumKey);
            //var items = order.OrderItems.Select(x => new ItemData(x.Product.Name, x.Quantity, decimal.ToInt32(x.Price))).ToList();
            PaymentData paymentData = new PaymentData(orderCode, (int)amount, description,
                items, _vietQRConfig.CancelUrl, _vietQRConfig.ReturnUrl);
            CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
            return createPayment;
        }

        public async Task<PaymentLinkInformation> GetPaymentLinkInformation(long orderCode)
        {
            PayOS payOS = new PayOS(_vietQRConfig.ClientId, _vietQRConfig.ApiKey, _vietQRConfig.ChecksumKey);

            PaymentLinkInformation paymentLinkInformation = await payOS.getPaymentLinkInformation(orderCode);

            return paymentLinkInformation;
        }
        public WebhookData VerifyPaymentWebhookData(WebhookType webhookData)
        {
            PayOS payOS = new PayOS(_vietQRConfig.ClientId, _vietQRConfig.ApiKey, _vietQRConfig.ChecksumKey);
            var data = payOS.verifyPaymentWebhookData(webhookData);
            if (data == null)
            {
                throw new BusinessException("Xác thực thanh toán thất bại");
            }
            return data;
            //var orderCode = data.orderCode;
            //var paymentStatus = data.paymentStatus;
            //var order = await _orderRepository.GetSingleAsync(x => x.OrderCode == orderCode);
            //if (order == null)
            //{
            //    throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            //}
            //if (paymentStatus == "SUCCESS")
            //{
            //    order.Status = OrderStatusEnum.Paid;
            //}
            //else
            //{
            //    order.Status = OrderStatusEnum.PaymentFailed;
            //}
            //await _orderRepository.UpdateAsync(order);
        }
    }
}
