using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class AppUserCustomerRepository : RepositoryBase<AppUserCustomer, Guid>, IAppUserCustomerRepository
    {
        public AppUserCustomerRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
