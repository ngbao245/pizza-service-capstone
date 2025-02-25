using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Net.payOS.Types;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class PaymentService : DomainService, IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPayOsService _payOsService;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IUnitOfWork unitOfWork, IPaymentRepository paymentRepository,
            IOrderRepository orderRepository, IPayOsService payOsService)
        {
            _unitOfWork = unitOfWork;
            _payOsService = payOsService;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<string> CreatePaymentQRCode(Guid orderId)
        {
            var order = await _orderRepository.GetSingleByIdAsync(orderId);
            if (order == null)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            if (order.Status != Enums.OrderStatusEnum.CheckedOut)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_CANNOT_PAY);
            var orderCode = GenerateOrderCode();
            var result = await _payOsService.CreatePaymentLink(orderCode, (int) order.TotalPrice!, "Thanh toán đơn hàng");
            var entity = new Payment(Guid.NewGuid(), order.TotalPrice.Value, PaymentMethodEnum.QRCode, orderId, orderCode.ToString());
            order.SetOrderCode(orderCode.ToString());
            _paymentRepository.Add(entity);
            _orderRepository.Update(order);
            await _unitOfWork.SaveChangeAsync();
            return result.qrCode;
        }
        public async Task<Guid> CreatePaymentCash(Guid orderId)
        {
            var order = await _orderRepository.GetSingleByIdAsync(orderId);
            if (order == null)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            if (order.Status != Enums.OrderStatusEnum.CheckedOut)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_CANNOT_PAY);
            var orderCode = GenerateOrderCode();
            var entity = new Payment(Guid.NewGuid(), order.TotalPrice!.Value, PaymentMethodEnum.Cash, orderId, orderCode.ToString());
            order.SetOrderCode(orderCode.ToString());
            entity.SetPaid();
            order.SetPaid();
            _paymentRepository.Add(entity);
            _orderRepository.Update(order);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
        public async Task<bool> ProcessWebhookData(WebhookType webhookData)
        {
            // Xác thực và lấy thông tin từ webhook thông qua gateway PayOS
            var result =  _payOsService.VerifyPaymentWebhookData(webhookData);
            if (result != null && result.code == "00")
            {
                // Giả sử result.OrderCode tương ứng với OrderId
                var payment = await _paymentRepository.GetSingleAsync(x => x.OrderCode == webhookData.data.orderCode.ToString());
                if (payment != null)
                {
                    payment.SetPaid();
                    _paymentRepository.Update(payment);
                    Console.WriteLine($"Payment {payment.Id} is paid, {payment}");
                }
                var order = await _orderRepository.GetSingleAsync(x => x.OrderCode == webhookData.data.orderCode.ToString());
                if (order != null)
                {
                    order.SetPaid();
                    _orderRepository.Update(order);
                    Console.WriteLine($"Order {order.Id} is paid, {order}");
                }
                await _unitOfWork.SaveChangeAsync();
                return true;
            }
            return false;
        }
        public long GenerateOrderCode()
        {
            long timestamp = DateTime.UtcNow.Ticks % 1_000_000_000; // 9 số cuối của Ticks
            int randomPart = new Random().Next(100, 999); // Thêm 3 số ngẫu nhiên
            return long.Parse($"{timestamp}{randomPart}");
        }
        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _paymentRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _paymentRepository.HardDelete(entity);
                }
                else
                {
                    _paymentRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _paymentRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _paymentRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, decimal amount, PaymentMethodEnum paymentMethod, string status, Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
