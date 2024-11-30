using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ScheduleConfigRepository : RepositoryBase<ScheduleConfig, Guid>, IScheduleConfigRepository
    {
        public ScheduleConfigRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
