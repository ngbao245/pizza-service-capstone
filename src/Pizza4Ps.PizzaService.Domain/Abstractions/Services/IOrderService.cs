using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IOrderService : IDomainService
    {
		Task<Guid> CreateAsync(DateTimeOffset startTime, Guid TableId);
		Task<Guid> UpdateAsync(Guid id, DateTimeOffset startTime, DateTimeOffset endTime, OrderStatusEnum status, Guid TableId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
		Task AddFoodToOrderAsync(Guid orderId, List<(Guid productId, List<Guid> optionItemIds, int quantity, string note)> items);       
		Task UpdateStatusToPendingAsync(Guid id);
		Task UpdateStatusToCompleteAsync(Guid id);
        Task CheckOutOrder(Guid orderId);
    }
}
