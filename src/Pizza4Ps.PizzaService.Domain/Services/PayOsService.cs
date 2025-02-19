using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Net.payOS;
using Net.payOS.Types;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
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

        public async Task<string> CreatePaymentLink(Guid tableId, string cancelUrl, string returnUrl)
        { 
            var table = await _tableRepository.GetSingleByIdAsync(tableId, "CurrentOrder");
            if (table == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }
            if (table.CurrentOrderId == null || table.CurrentOrder == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_HAVE_ORDER);
            }
            if (table.CurrentOrder.TotalPrice == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_ORDER_NOT_HAVE_TOTAL_PRICE);
            }
            var orderItems = _orderItemRepository.GetListAsNoTracking(x => x.OrderId == table.CurrentOrderId)
                .Include(x => x.Product);
            if (orderItems == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_ORDER_NOT_HAVE_ORDER_ITEM);
            }    
            PayOS payOS = new PayOS(_vietQRConfig.ClientId, _vietQRConfig.ApiKey, _vietQRConfig.ChecksumKey);
            var items = orderItems.Select(x => new ItemData(x.Product.Name, x.Quantity, decimal.ToInt32(x.Price))).ToList();
            var orderCode = GenerateOrderCode();
            PaymentData paymentData = new PaymentData(orderCode, decimal.ToInt32(table.CurrentOrder.TotalPrice.Value), "Thanh toan don hang",
                items, cancelUrl, returnUrl);
            CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
            return createPayment.qrCode;
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
