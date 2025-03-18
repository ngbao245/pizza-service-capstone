using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class SizeRepository : RepositoryBase<Size, Guid>, ISizeRepository
    {
        public SizeRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
