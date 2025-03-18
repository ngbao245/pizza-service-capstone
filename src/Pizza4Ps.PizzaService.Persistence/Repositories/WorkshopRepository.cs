using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class WorkshopRepository : RepositoryBase<Workshop, Guid>, IWorkshopRepository
    {
        public WorkshopRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
