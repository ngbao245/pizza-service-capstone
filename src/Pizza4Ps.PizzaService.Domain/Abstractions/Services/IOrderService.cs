using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IOrderService : IDomainService
    {
		Task<Guid> CreateAsync(DateTimeOffset startTime, DateTimeOffset endTime, OrderTypeEnum status, Guid TableId);
		Task<Guid> UpdateAsync(Guid id, DateTimeOffset startTime, DateTimeOffset endTime, OrderTypeEnum status, Guid TableId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
		Task<Guid> AddFoodToOrderAsync(Guid tableId, List<(Guid ProductId, List<Guid> OptionItemIds, string Note)> items);
        Task UpdateStatusToPendingAsync(Guid id);
		Task UpdateStatusToCompleteAsync(Guid id);
	}
}
