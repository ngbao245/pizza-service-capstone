using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IProductSizeService: IDomainService
    {
        Task<Guid> CreateAsync(Guid productId, Guid recipeId, Guid sizeId);
    }
}
