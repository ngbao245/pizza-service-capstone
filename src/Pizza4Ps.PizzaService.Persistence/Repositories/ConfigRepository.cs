using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ConfigRepository : RepositoryBase<Config, Guid>, IConfigRepository
    {
        public ConfigRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
