using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class WorkshopPizzaRegisterRepository : RepositoryBase<WorkshopPizzaRegister, Guid>, IWorkshopPizzaRegisterRepository
    {
        public WorkshopPizzaRegisterRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
