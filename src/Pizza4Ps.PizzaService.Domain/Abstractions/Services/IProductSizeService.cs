using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IProductSizeService : IDomainService
    {
        Task<Guid> CreateAsync(string name, decimal diameter, string? description, Guid productId);
    }
}
