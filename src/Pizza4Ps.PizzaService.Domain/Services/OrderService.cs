using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;
using System.Xml.Linq;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class OrderService : DomainService, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptionItemOrderItemRepository _optionItemOrderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOptionItemRepository _optionItemRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderService(IUnitOfWork unitOfWork,
            IOptionItemOrderItemRepository optionItemOrderItemRepository,
            IOrderRepository orderRepository,
            ITableRepository tableRepository,
            IProductRepository productRepository,
            IOptionItemRepository optionItemRepository,
            IOrderItemRepository orderItemRepository)
        {
            _unitOfWork = unitOfWork;
            _optionItemOrderItemRepository = optionItemOrderItemRepository;
            _orderRepository = orderRepository;
            _tableRepository = tableRepository;
            _productRepository = productRepository;
            _optionItemRepository = optionItemRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Guid> CreateAsync(DateTimeOffset startTime, Guid tableId)
        {
            var entity = new Order(Guid.NewGuid(), startTime, tableId);
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

        public async Task<Guid> UpdateAsync(Guid id, DateTimeOffset startTime, DateTimeOffset endTime, OrderStatusEnum status, Guid tableId)
        {
            var entity = await _orderRepository.GetSingleByIdAsync(id);
            entity.UpdateOrder(startTime, endTime, status, tableId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task AddFoodToOrderAsync(Guid tableId, List<(Guid productId, List<Guid> optionItemIds, int quantity, string note)> items)
        {
            var table = await _tableRepository.GetSingleByIdAsync(tableId, "CurrentOrder");
            if (table == null) throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            if (table.CurrentOrderId == null)
            {
                var order = new Order(
                    id: Guid.NewGuid(),
                    startTime: DateTimeOffset.Now,
                    tableId: tableId);
                table.SetCurrentOrderId(order.Id);
                _orderRepository.Add(order);
                foreach (var item in items)
                {
                    var product = await _productRepository.GetSingleByIdAsync(item.productId);
                    if (product == null) throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
                    var orderItem = new OrderItem(
                        id: Guid.NewGuid(),
                        name: product.Name,
                        quantity: item.quantity,
                        price: product.Price,
                        orderId: order.Id,
                        productId: product.Id);
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
                            optionItemId: optionItemId,
                            orderItemId: orderItem.Id
                            );
                        _optionItemOrderItemRepository.Add(orderDetail);
                    }
                }
            }
            else if (table.CurrentOrderId != null)
            {
                if (table.CurrentOrder.Status != OrderStatusEnum.Unpaid) throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_STATUS_INVALID_TO_ORDER);
                foreach (var item in items)
                {
                    var product = await _productRepository.GetSingleByIdAsync(item.productId);
                    if (product == null) throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
                    var orderItem = new OrderItem(
                        id: Guid.NewGuid(),
                        name: product.Name,
                        quantity: item.quantity,
                        price: product.Price,
                        orderId: table.CurrentOrderId.Value,
                        productId: product.Id);
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
                            optionItemId: optionItemId,
                            orderItemId: orderItem.Id
                            );
                        _optionItemOrderItemRepository.Add(orderDetail);
                    }
                }
            }
            await _unitOfWork.SaveChangeAsync();
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

        public Task CheckOutOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatusToPendingAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
