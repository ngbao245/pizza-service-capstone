using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IOrderService : IDomainService
    {
		Task<Guid> CreateAsync(Guid TableId, OrderTypeEnum type);
		Task<Guid> UpdateAsync(Guid id, DateTime startTime, DateTime endTime, OrderStatusEnum status, Guid TableId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
		Task AddFoodToOrderAsync(Guid orderId, List<(Guid productId, List<Guid> optionItemIds, int quantity, string note)> items);       
		Task UpdateStatusToPendingAsync(Guid id);
		Task UpdateStatusToCompleteAsync(Guid id);
        Task CheckOutOrder(Guid orderId);
        Task CancelCheckOut(Guid orderId);
		Task CancelOrder(Guid orderId, string? note);
		Task SwapTableOrder(Guid orderId, Guid tableId);
    }
}
