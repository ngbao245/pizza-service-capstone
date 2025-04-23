using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using static Pizza4Ps.PizzaService.Domain.Constants.BussinessErrorConstants;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class OrderService : DomainService, IOrderService
    {
        private readonly IRealTimeNotifier _realTimeNotifier;
        private readonly IAdditionalFeeRepository _additionalFeeRepository;
        private readonly IConfigRepository _configRepository;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderItemDetailRepository _orderItemDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderVoucherRepository _orderVoucherRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOptionItemRepository _optionItemRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderService(
            IRealTimeNotifier realTimeNotifier,
            IUnitOfWork unitOfWork,
            IOrderItemDetailRepository orderItemDetailRepository,
            IOrderRepository orderRepository,
            ITableRepository tableRepository,
            IProductRepository productRepository,
            IOptionItemRepository optionItemRepository,
            IOrderItemRepository orderItemRepository,
            IOrderVoucherRepository orderVoucherRepository,
            IWorkshopRegisterRepository workshopRegisterRepository,
            IConfigRepository configRepository,
            IAdditionalFeeRepository additionalFeeRepository
            )
        {
            _realTimeNotifier = realTimeNotifier;
            _additionalFeeRepository = additionalFeeRepository;
            _configRepository = configRepository;
            _workshopRegisterRepository = workshopRegisterRepository;
            _unitOfWork = unitOfWork;
            _orderItemDetailRepository = orderItemDetailRepository;
            _orderRepository = orderRepository;
            _tableRepository = tableRepository;
            _productRepository = productRepository;
            _optionItemRepository = optionItemRepository;
            _orderItemRepository = orderItemRepository;
            _orderVoucherRepository = orderVoucherRepository;
        }

        public async Task<Guid> CreateAsync(Guid tableId, OrderTypeEnum type)
        {
            var table = await _tableRepository.GetSingleByIdAsync(tableId);
            if (table.CurrentOrderId != null) throw new BusinessException(CurrentOrderIdExisted.CURRENT_ORDER_ID_EXISTED);
            var entity = new Order(Guid.NewGuid(), tableId, table.Code, type);
            if (table.TableMergeId != null)
            {
                var tablesMerge = await _tableRepository.GetListAsTracking(x => x.TableMergeId == table.TableMergeId).ToListAsync();
                foreach (var tableMerge in tablesMerge)
                {
                    tableMerge.SetCurrentOrderId(entity.Id);
                    _tableRepository.Update(tableMerge);
                }
            }
            else
            {
                table.SetCurrentOrderId(entity.Id);

                _tableRepository.Update(table);
            }

            _orderRepository.Add(entity);

            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _orderRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _orderRepository.HardDelete(entity);
                }
                else
                {
                    _orderRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _orderRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _orderRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, DateTime startTime, DateTime endTime, OrderStatusEnum status, Guid tableId)
        {
            var entity = await _orderRepository.GetSingleByIdAsync(id);
            entity.UpdateOrder(startTime, endTime, status, tableId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task AddFoodToOrderAsync(Guid orderId, List<(Guid productId, List<Guid> optionItemIds, int quantity, string note)> items)
        {
            var createTime = DateTime.Now;
            var order = await _orderRepository.GetSingleByIdAsync(orderId);
            if (order == null) throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            if (order.Status != OrderStatusEnum.Unpaid) throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_STATUS_INVALID_TO_ORDER);
            foreach (var item in items)
            {
                var product = await _productRepository.GetSingleByIdAsync(item.productId, "ProductComboSlots.ProductComboSlotItems.Product");
                if (product == null) throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);

                if (product.ProductRole == ProductRoleEnum.Combo)
                {
                    // 1. Lấy base price của combo
                    decimal baseComboPrice = product.Price;

                    // 2. Lấy các slot‑item khách đã chọn
                    var selectedSlotItems = product.ProductComboSlots
                        .SelectMany(slot => slot.ProductComboSlotItems)
                        .Where(i => item.optionItemIds.Contains(i.Id))
                        .ToList();

                    // 3. Tính tổng extraPrice
                    decimal totalExtra = selectedSlotItems.Sum(i => i.ExtraPrice);

                    // 4. Tính giá combo cho 1 đơn vị
                    decimal pricePerCombo = baseComboPrice;

                    // 5. Tính tổng cho toàn bộ quantity
                    decimal finalComboPrice = pricePerCombo * item.quantity;
                    // 1. Tạo order item cha
                    var parent = new OrderItem(
                        id: Guid.NewGuid(),
                        name: product.Name,
                        quantity: item.quantity,
                        price: product.Price,
                        orderId: order.Id,
                        productId: product.Id,
                        tableCode: order.TableCode,
                        note: item.note,
                        type: OrderTypeEnum.Order,
                        startTime: createTime,
                        productType: null,
                        isProductCombo: true,
                        parentId: null
                    );
                    parent.setDone();
                    parent.SetTotalPriceCombo(finalComboPrice);
                    _orderItemRepository.Add(parent);
                    foreach (var slot in product.ProductComboSlots)
                    {
                        // Khách chọn item nào (ví dụ: đã map vào dto nếu cần)
                        var selectedItem = slot.ProductComboSlotItems
                            .FirstOrDefault(i => item.optionItemIds.Contains(i.Id));
                        if (selectedItem == null)
                            throw new BusinessException("Lựa chọn món trong combo không hợp lệ");

                        var child = new OrderItem(
                            id: Guid.NewGuid(),
                            name: selectedItem.Product.Name,
                            quantity: item.quantity,
                            price: selectedItem.ExtraPrice,
                            orderId: order.Id,
                            productId: selectedItem.ProductId,
                            tableCode: order.TableCode,
                            note: item.note,
                            type: OrderTypeEnum.Order,
                            startTime: createTime,
                            productType: selectedItem.Product.ProductType,
                            isProductCombo: false,
                            parentId: parent.Id
                        );
                        child.SetTotalPriceCombo(selectedItem.ExtraPrice * item.quantity);
                        _orderItemRepository.Add(child);
                    }
                }
                else
                {
                    var orderItem = new OrderItem(
                        id: Guid.NewGuid(),
                        name: product.Name,
                        quantity: item.quantity,
                        price: product.Price,
                        orderId: order.Id,
                        productId: product.Id,
                        tableCode: order.TableCode,
                        note: item.note,
                        type: OrderTypeEnum.Order,
                        startTime: createTime,
                        productType: product.ProductType,
                        isProductCombo: false,
                        parentId: null);
                    _orderItemRepository.Add(orderItem);
                    var optionItems = await _optionItemRepository.GetListAsTracking(x => item.optionItemIds.Contains(x.Id)).ToListAsync();
                    foreach (var optionItemId in item.optionItemIds)
                    {
                        var optionItem = optionItems.FirstOrDefault(x => x.Id == optionItemId);
                        if (optionItem == null) throw new BusinessException(BussinessErrorConstants.OptionItemErrorConstant.OPTION_ITEM_NOT_FOUND);
                        var orderDetail = new OrderItemDetail(
                            id: Guid.NewGuid(),
                            name: optionItem.Name,
                            additionalPrice: optionItem.AdditionalPrice,
                            orderItemId: orderItem.Id
                            );
                        //_optionItemOrderItemRepository.Add(orderDetail);
                        orderItem.OrderItemDetails.Add(orderDetail);
                    }
                    orderItem.SetTotalPrice();
                }
            }

            await _unitOfWork.SaveChangeAsync();
            await _realTimeNotifier.UpdateOrderItemStatusAsync();
        }


        //public async Task UpdateStatusToPendingAsync(Guid id)
        //{
        //    var entity = await _orderRepository.GetSingleByIdAsync(id);
        //    if (entity == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
        //    entity.UpdateOrder(entity.StartTime, entity.EndTime, OrderStatusEnum.Cooking, entity.TableId);
        //    await _unitOfWork.SaveChangeAsync();
        //}

        public Task UpdateStatusToCompleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task CheckOutOrder(Guid orderId)
        {
            decimal totalPrice = 0;
            var order = await _orderRepository.GetSingleByIdAsync(orderId, "OrderItems,AdditionalFees");
            if (order == null)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            if (order.Status != OrderStatusEnum.Unpaid)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_CANNOT_CHECK_OUT);
            //Validate các món phải done hết mới được checkout
            decimal totalOrderItemPrice = 0;
            foreach (var orderItem in order.OrderItems)
            {
                //if (orderItem.OrderItemStatus != OrderItemStatus.Done && orderItem.OrderItemStatus != OrderItemStatus.Cancelled)
                //{
                //    throw new BusinessException("Đơn hàng có món ăn chưa được hoàn thành hoặc huỷ");
                //}
                if (orderItem.OrderItemStatus != OrderItemStatus.Cancelled)
                {

                    totalOrderItemPrice += orderItem.TotalPrice;
                }
            }
            var additionalFees = new List<AdditionalFee>();
            var workshopAdditionalFees = new List<AdditionalFee>();
            if (order.Type == OrderTypeEnum.Workshop)
            {
                var workshopRegister = await _workshopRegisterRepository.GetSingleAsync(x => x.OrderId == order.Id);
                if (workshopRegister == null)
                {
                    throw new BusinessException("Không tìm thấy thông tin đăng ký workshop");
                }
                var additionalFee = new AdditionalFee(
                    id: Guid.NewGuid(),
                    name: "Workshop fee",
                    description: "Workshop fee",
                    value: workshopRegister.TotalFee,
                    orderId: order.Id
                    );
                workshopAdditionalFees.Add(additionalFee);
            }
            // Tính voucher
            var voucherAdditionalFees = new List<AdditionalFee>();
            var orderVouchers = await _orderVoucherRepository.GetListAsNoTracking(x => x.OrderId == order.Id)
                .Include(x => x.Voucher)
                .ToListAsync();
            if (orderVouchers != null && orderVouchers.Any())
            {
                foreach (var orderVoucher in orderVouchers)
                {
                    if (orderVoucher.Voucher.DiscountType == DiscountTypeEnum.Direct)
                    {
                        var additionalVoucher = new AdditionalFee(
                            id: Guid.NewGuid(),
                            name: $"Voucher discount",
                            description: "Voucher discount",
                            value: -orderVoucher.Voucher.DiscountValue,
                            orderId: order.Id);
                        voucherAdditionalFees.Add(additionalVoucher);
                    }
                    else if (orderVoucher.Voucher.DiscountType == DiscountTypeEnum.Percentage)
                    {
                        var totalDiscount = ((totalOrderItemPrice + workshopAdditionalFees.Sum(x => x.Value)) * orderVoucher.Voucher.DiscountValue) / 100;
                        var additionalVoucher = new AdditionalFee(
                            id: Guid.NewGuid(),
                            name: $"Voucher {orderVoucher.Voucher.DiscountValue}%",
                            description: "Voucher discount",
                            value: -totalDiscount,
                            orderId: order.Id);
                        voucherAdditionalFees.Add(additionalVoucher);
                    }
                }
            }
            // Tính thuế
            var vatAdditionalFees = new List<AdditionalFee>();
            var vatFee = await _configRepository.GetSingleAsync(x => x.ConfigType == ConfigType.VAT);
            if (vatFee != null && decimal.Parse(vatFee.Value) != 0)
            {
                decimal totalPriceCalVat = totalOrderItemPrice + workshopAdditionalFees.Sum(x => x.Value);
                decimal totalVatFee = 0;
                if (totalPriceCalVat > 0)
                {
                    totalVatFee = (totalPriceCalVat * decimal.Parse(vatFee.Value)) / 100;
                }
                var additionalFee = new AdditionalFee(
                    id: Guid.NewGuid(),
                    name: $"VAT ({vatFee.Value}%)",
                    description: "Thuế",
                    value: totalVatFee,
                    orderId: order.Id
                    );
                vatAdditionalFees.Add(additionalFee);
            }
            additionalFees.AddRange(workshopAdditionalFees);
            additionalFees.AddRange(vatAdditionalFees);
            additionalFees.AddRange(voucherAdditionalFees);

            var totalAdditionalFees = additionalFees.Sum(x => x.Value);
            totalPrice = totalOrderItemPrice + totalAdditionalFees;
            if (totalPrice < 0)
            {
                totalPrice = 0;
            }
            order.SetCheckOut();
            order.SetTotalPrice(totalPrice);
            order.SetTotalAdditionalFeePrice(totalAdditionalFees);
            order.SetTotalOrderItemPrice(totalOrderItemPrice);

            _additionalFeeRepository.AddRange(additionalFees);
            _orderRepository.Update(order);

            //var orderVouchers = await _orderVoucherRepository
            //.GetListAsTracking(ov => ov.OrderId == orderId)
            //.ToListAsync();

            //foreach (var ov in orderVouchers)
            //{
            //    ov.SetUsed();
            //    _orderVoucherRepository.Update(ov);
            //}

            await _unitOfWork.SaveChangeAsync();
        }

        public async Task CancelCheckOut(Guid orderId)
        {
            decimal total = 0;
            var order = await _orderRepository.GetSingleByIdAsync(orderId, "AdditionalFees");
            if (order == null)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            if (order.Status != OrderStatusEnum.CheckedOut)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_CANNOT_CHECK_OUT);
            order.SetTotalPrice(total);
            order.SetTotalAdditionalFeePrice(total);
            order.SetTotalOrderItemPrice(total);
            order.SetCancelCheckOut();

            foreach (var additionalFee in order.AdditionalFees)
            {
                _additionalFeeRepository.HardDelete(additionalFee);
            }
            //var orderVouchers = await _orderVoucherRepository
            //.GetListAsTracking(ov => ov.OrderId == orderId)
            //.ToListAsync();

            //foreach (var ov in orderVouchers)
            //{
            //    ov.Cancel();
            //    _orderVoucherRepository.Update(ov);
            //}

            await _unitOfWork.SaveChangeAsync();
        }

        public Task UpdateStatusToPendingAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task CancelOrder(Guid orderId, string? note)
        {
            var order = await _orderRepository.GetSingleByIdAsync(orderId);
            if (order == null)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            order.SetCancelOrder(note);

            var tables = await _tableRepository.GetListAsTracking(x => x.CurrentOrderId == order.Id).ToListAsync();
            foreach (var table in tables)
            {
                if (table != null)
                {
                    table.SetNullCurrentOrderId();
                    _tableRepository.Update(table);
                }
            }
            _orderRepository.Update(order);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task SwapTableOrder(Guid orderId, Guid tableId)
        {
            var order = await _orderRepository.GetSingleByIdAsync(orderId);
            if (order == null)
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            var table = await _tableRepository.GetSingleAsync(x => x.CurrentOrderId == order.Id);
            if (table.TableMergeId != null)
                throw new BusinessException("Bàn đang được ghép, không thể đổi bàn");
            if (table != null)
            {
                table.SetNullCurrentOrderId();
                table.SetClosing();
                _tableRepository.Update(table);
            }
            var newTable = await _tableRepository.GetSingleByIdAsync(tableId);
            if (newTable == null)
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            if (newTable.TableMergeId != null)
                throw new BusinessException("Bàn đang được ghép, không thể đổi bàn");
            if (newTable.CurrentOrderId != null)
                throw new BusinessException("Bàn muốn đổi đang có đơn hàng, không thể đổi bàn");
            if (newTable.Status != TableStatusEnum.Closing)
            {
                throw new BusinessException("Bàn hiện tại đang được sử dụng");
            }
            newTable.SetOpening();
            newTable.SetCurrentOrderId(order.Id);
            _tableRepository.Update(newTable);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
