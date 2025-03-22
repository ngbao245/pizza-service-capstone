using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface ISizeService : IDomainService
    {
        Task<Guid> CreateAsync(string name, int diameterCm, string? description);
    }
}
