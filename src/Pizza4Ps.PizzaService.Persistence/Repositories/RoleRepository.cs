using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class RoleRepository : RepositoryBase<Role, Guid>, IRoleRepository
    {
        public RoleRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
