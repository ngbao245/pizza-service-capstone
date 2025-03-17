using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories.RepositoryBase;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Repositories
{
    public interface IAppUserCustomerRepository : IRepositoryBase<AppUserCustomer, Guid>
    {
    }
}
