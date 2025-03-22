using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class WorkingSlotRepository : RepositoryBase<WorkingSlot, Guid>, IWorkingSlotRepository
    {
        public WorkingSlotRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
