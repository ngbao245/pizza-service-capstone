using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class WorkshopRegisterRepository : RepositoryBase<WorkshopRegister, Guid>, IWorkshopRegisterRepository
    {
        public WorkshopRegisterRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
