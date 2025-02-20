using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface ITableService : IDomainService
    {
        Task<Guid> CreateAsync(int tableNumber, int capacity, TableStatusEnum status, Guid zoneId);
        Task<Guid> UpdateAsync(Guid id, int tableNumber, int capacity, TableStatusEnum status, Guid zoneId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
