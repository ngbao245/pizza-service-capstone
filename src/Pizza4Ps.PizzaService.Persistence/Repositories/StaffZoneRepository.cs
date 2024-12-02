using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class StaffZoneRepository : RepositoryBase<StaffZone, Guid>, IStaffZoneRepository
    {
        public StaffZoneRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
