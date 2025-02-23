using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IOrderItemService
    {
        Task<Guid> CreateAsync(string name, string? note, int quantity, decimal price, Guid orderId, Guid productId, OrderItemStatus orderItemStatus);
        Task<Guid> UpdateAsync(Guid id, string name, int quantity, decimal price, Guid orderId, Guid productId, OrderItemStatus orderItemStatus);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
        Task UpdateStatusToServingAsync(Guid id);
        Task UpdateStatusToDoneAsync(Guid id);
        Task UpdateStatusToCancelledAsync(Guid id);
    }
}
