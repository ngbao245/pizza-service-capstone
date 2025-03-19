using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class WorkshopPizzaRegisterDetailRepository : RepositoryBase<WorkshopPizzaRegisterDetail, Guid>, IWorkshopPizzaRegisterDetailRepository
    {
        public WorkshopPizzaRegisterDetailRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
