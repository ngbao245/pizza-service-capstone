using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class OrderService : DomainService, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOptionItemRepository _optionItemRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository, ITableRepository tableRepository, IProductRepository productRepository, IOptionItemRepository optionItemRepository, IOrderItemRepository orderItemRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _tableRepository = tableRepository;
            _productRepository = productRepository;
            _optionItemRepository = optionItemRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Guid> CreateAsync(DateTimeOffset startTime, DateTimeOffset endTime, OrderTypeEnum status, Guid tableId)
        {
            var entity = new Order(Guid.NewGuid(), startTime, endTime, status, tableId);
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

        public async Task<Guid> UpdateAsync(Guid id, DateTimeOffset startTime, DateTimeOffset endTime, OrderTypeEnum status, Guid tableId)
        {
            var entity = await _orderRepository.GetSingleByIdAsync(id);
            entity.UpdateOrder(startTime, endTime, status, tableId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task<bool> AddFoodToOrderAsync(Guid tableId, List<(Guid ProductId, List<Guid> OptionItemIds, string Note)> items)
        {
                var order = await _orderRepository.GetSingleAsync(o => o.TableId == tableId && o.Status == OrderTypeEnum.Cooking);
                if (order == null)
                {
                    order = new Order(Guid.NewGuid(), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddHours(2), OrderTypeEnum.Cooking, tableId);
                    _orderRepository.Add(order);
                }
                foreach (var (productId, optionItemIds, note) in items)
                {
                    var product = await _productRepository.GetSingleByIdAsync(productId);
                    var orderItem = new OrderItem(Guid.NewGuid(), product.Name, 1, product.Price, order.Id, productId, OrderItemTypeEnum.Cooking);
                    var optionItems = await _optionItemRepository
                        .GetListAsTracking(o => optionItemIds.Contains(o.Id))
                        .ToListAsync();


                orderItem.OrderItemDetails = optionItems.Select(optionItem =>
                        new OrderItemDetail(
                            Guid.NewGuid(),
                            optionItem.Name,
                            optionItem.AdditionalPrice,
                            optionItem.Id,
                            orderItem.Id
                        )).ToList();

                    _orderItemRepository.Add(orderItem);
                }

                return true;

        }

    }
}
