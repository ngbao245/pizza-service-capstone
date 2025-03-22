using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IRecipeService : IDomainService
    {
        Task<Guid> CreateAsync(string unit, string name);
    }
}
