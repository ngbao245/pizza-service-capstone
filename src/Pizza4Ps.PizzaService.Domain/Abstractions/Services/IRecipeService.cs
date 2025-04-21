using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IRecipeService : IDomainService
    {
        Task<Guid> CreateAsync(Guid productId, Guid? ingredientId, string ingredientName, UnitOfMeasurementType unit, decimal quantity);
        Task DeleteAsync(List<Guid> ids, bool isHardDelete);
        Task RestoreAsync(List<Guid> ids);
    }
}
