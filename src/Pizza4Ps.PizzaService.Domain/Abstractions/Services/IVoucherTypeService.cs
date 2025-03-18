using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IVoucherTypeService : IDomainService
    {
		Task<Guid> CreateAsync(string name, string description, int totalQuantity);
    }
}
