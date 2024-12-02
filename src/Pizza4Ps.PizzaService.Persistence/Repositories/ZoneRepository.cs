using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ZoneRepository : RepositoryBase<Zone, Guid>, IZoneRepository
    {
        public ZoneRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
