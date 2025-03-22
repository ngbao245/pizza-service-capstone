using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class WorkingSlotRegisterRepository : RepositoryBase<WorkingSlotRegister, Guid>, IWorkingSlotRegisterRepository
    {
        public WorkingSlotRegisterRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
