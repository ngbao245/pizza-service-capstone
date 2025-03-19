using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IAdditionalFeeService : IDomainService
    {
        Task<Guid> CreateAsync(string name, string description, decimal value, Guid orderId);
    }
}
