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
        private readonly ITableMergeRepository _tableMergeRepository;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IOrderVoucherRepository _orderVoucherRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPayOsService _payOsService;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ITableRepository _tableRepository;

        public PaymentService(
            IUnitOfWork unitOfWork,
            IPayOsService payOsService,
            IOrderRepository orderRepository,
            IPaymentRepository paymentRepository,
            ITableRepository tableRepository,
            IOrderVoucherRepository orderVoucherRepository,
            IVoucherRepository voucherRepository, ITableMergeRepository tableMergeRepository)
        {
            _tableMergeRepository = tableMergeRepository;
            _voucherRepository = voucherRepository;
            _orderVoucherRepository = orderVoucherRepository;
            _unitOfWork = unitOfWork;
            _payOsService = payOsService;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _tableRepository = tableRepository;
        }

        public async Task<string> CreatePaymentQRCode(Guid orderId)
        {
            var voucherUses = await _orderVoucherRepository.GetListAsTracking(x => x.OrderId == orderId)
                .Include(x => x.Voucher)
                .ToListAsync();

            if (voucherUses != null)
            {
                foreach (var voucherUse in voucherUses)
                {
                    var voucher = voucherUse.Voucher;
                    if (voucher.VoucherStatus != VoucherStatus.Available)
                    {
                        throw new BusinessException($"Voucher {voucher.Code} đã được sử dụng hoặc không hợp lệ");
                    }
                    voucher.SetPendingPayment();
                    _voucherRepository.Update(voucher);
                }
            }
            var order = await _orderRepository.GetSingleByIdAsync(orderId);
            if (order == null)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            if (order.Status != Enums.OrderStatusEnum.CheckedOut)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_CANNOT_PAY);
            var orderCode = GenerateOrderCode();
            var result = await _payOsService.CreatePaymentLink(orderCode, (int)order.TotalPrice!, "Thanh toán đơn hàng");
            order.SetOrderCode(orderCode.ToString());
            _orderRepository.Update(order);

            await _unitOfWork.SaveChangeAsync();
            return result.qrCode;
        }
        public async Task CancelPaymentQRCode(Guid orderId)
        {
            var voucherUses = await _orderVoucherRepository.GetListAsTracking(x => x.OrderId == orderId)
                .Include(x => x.Voucher)
                .ToListAsync();

            if (voucherUses != null)
            {
                foreach (var voucherUse in voucherUses)
                {
                    var voucher = voucherUse.Voucher;
                    if (voucher.VoucherStatus != VoucherStatus.PendingPayment)
                    {
                        throw new BusinessException($"Voucher {voucher.Code} đã được sử dụng hoặc không hợp lệ");
                    }
                    voucher.SetAvailable();
                    _voucherRepository.Update(voucher);
                }
            }
            var order = await _orderRepository.GetSingleByIdAsync(orderId);
            if (order == null)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);

            order.SetOrderCode(null);
            _orderRepository.Update(order);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> CreatePaymentCash(Guid orderId)
        {
            var voucherUses = await _orderVoucherRepository.GetListAsTracking(x => x.OrderId == orderId)
                .Include(x => x.Voucher)
                .ToListAsync();

            if (voucherUses != null)
            {
                foreach (var voucherUse in voucherUses)
                {
                    var voucher = voucherUse.Voucher;
                    if (voucher.VoucherStatus != VoucherStatus.Available)
                    {
                        throw new BusinessException($"Voucher {voucher.Code} đã được sử dụng hoặc không hợp lệ");
                    }
                    voucher.SetUsed();
                    _voucherRepository.Update(voucher);
                }
            }
            var order = await _orderRepository.GetSingleByIdAsync(orderId);
            if (order == null)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            if (order.Status != Enums.OrderStatusEnum.CheckedOut)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_CANNOT_PAY);
            var orderCode = GenerateOrderCode();
            var entity = new Payment(Guid.NewGuid(), order.TotalPrice!.Value, PaymentMethodEnum.Cash, orderId, orderCode.ToString());
            order.SetOrderCode(orderCode.ToString());
            order.SetPaid();

            var tables = await _tableRepository.GetListAsTracking(x => x.CurrentOrderId == orderId).ToListAsync();
            foreach (var table in tables)
            {
                if (table != null)
                {
                    table.SetNullCurrentOrderId();
                    table.SetClosing();
                    if (table.TableMergeId != null)
                    {
                        var tableMerge = await _tableMergeRepository.GetSingleByIdAsync(table.TableMergeId.Value);
                        table.CancelMerge();
                        _tableMergeRepository.HardDelete(tableMerge);
                    }
                    _tableRepository.Update(table);
                }
            }

            _paymentRepository.Add(entity);
            _orderRepository.Update(order);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
        public async Task<bool> ProcessWebhookData(WebhookType webhookData)
        {
            // Xác thực và lấy thông tin từ webhook thông qua gateway PayOS
            try
            {
                var result = _payOsService.VerifyPaymentWebhookData(webhookData);
                if (result != null && result.code == "00")
                {
                    var order = await _orderRepository.GetSingleAsync(x => x.OrderCode == webhookData.data.orderCode.ToString());
                    if (order == null)
                        throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
                    order.SetPaid();
                    _orderRepository.Update(order);
                    var entity = new Payment(Guid.NewGuid(), order.TotalPrice!.Value, PaymentMethodEnum.QRCode, order.Id, webhookData.data.orderCode.ToString());
                    _paymentRepository.Add(entity);
                    Console.WriteLine($"Order {order.Id} is paid, {order}");


                    var tables = await _tableRepository.GetListAsTracking(x => x.CurrentOrderId == order.Id).ToListAsync();
                    foreach (var table in tables)
                    {
                        if (table != null)
                        {
                            table.SetNullCurrentOrderId();
                            table.SetClosing();
                            if (table.TableMergeId != null)
                            {
                                var tableMerge = await _tableMergeRepository.GetSingleByIdAsync(table.TableMergeId.Value);
                                table.CancelMerge();
                                _tableMergeRepository.HardDelete(tableMerge);
                            }
                            _tableRepository.Update(table);
                        }
                    }

                    var voucherUses = await _orderVoucherRepository.GetListAsTracking(x => x.OrderId == order.Id)
                        .Include(x => x.Voucher)
                        .ToListAsync();

                    if (voucherUses != null)
                    {
                        foreach (var voucherUse in voucherUses)
                        {
                            var voucher = voucherUse.Voucher;
                            if (voucher.VoucherStatus != VoucherStatus.PendingPayment)
                            {
                                throw new BusinessException("Voucher không hợp lệ");
                            }
                            voucher.SetUsed();
                            _voucherRepository.Update(voucher);
                        }
                    }

                    await _unitOfWork.SaveChangeAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
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
