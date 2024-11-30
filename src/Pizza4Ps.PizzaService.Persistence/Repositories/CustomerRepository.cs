using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
