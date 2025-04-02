using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IConfigService : IDomainService
    {
        Task<Guid> UpdateValueAsync(Guid id, string value);
    }
}
