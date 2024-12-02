using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class StaffScheduleLogRepository : RepositoryBase<StaffScheduleLog, Guid>, IStaffScheduleLogRepository
    {
        public StaffScheduleLogRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
