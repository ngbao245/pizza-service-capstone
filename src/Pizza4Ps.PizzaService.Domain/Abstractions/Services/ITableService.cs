using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface ITableService : IDomainService
    {
        Task<Guid> CreateAsync(string code, int capacity, Guid zoneId);
        Task<Guid> CloseTable(Guid tableId);
        Task<Guid> OpenTable(Guid tableId);
        Task<Guid> LockTable(Guid tableId, string? note);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
        Task<Guid> UpdateAsync(Guid id, string code, int capacity, Guid zoneId);
    }
}
