using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IProductService : IDomainService
    {
        Task<Guid> CreateAsync(string name, decimal price, string description, Guid categoryId);
        Task<Guid> UpdateAsync(Guid id, string name, decimal price, string description, Guid categoryId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
