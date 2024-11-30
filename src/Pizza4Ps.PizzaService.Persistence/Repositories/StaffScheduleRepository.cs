using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class StaffScheduleRepository : RepositoryBase<StaffSchedule, Guid>, IStaffScheduleRepository
    {
        public StaffScheduleRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
