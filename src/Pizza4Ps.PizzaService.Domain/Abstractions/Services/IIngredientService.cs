using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IIngredientService : IDomainService
    {
        Task<Guid> CreateAsync(string name, string description);
        Task DeleteAsync(List<Guid> ids, bool isHardDelete);
        Task RestoreAsync(List<Guid> ids);
    }
}
