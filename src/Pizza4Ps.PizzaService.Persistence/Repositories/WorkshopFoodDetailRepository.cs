using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class WorkshopFoodDetailRepository : RepositoryBase<WorkshopFoodDetail, Guid>, IWorkshopFoodDetailRepository
    {
        public WorkshopFoodDetailRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
