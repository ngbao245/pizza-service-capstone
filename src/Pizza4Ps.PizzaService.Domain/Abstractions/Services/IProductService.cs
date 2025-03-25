using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IProductService : IDomainService
    {
        Task<Guid> CreateAsync(string name, decimal price, byte[]? image, string? description, Guid categoryId, ProductTypeEnum productType, string? imageUrl, string? imagePublicId);
        Task<Guid> UpdateAsync(Guid id, string name, decimal price, byte[]? image, string? description, Guid categoryId, ProductTypeEnum productType, string? imageUrl, string? imagePublicId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
