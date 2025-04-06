using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ReasonConfigRepository : RepositoryBase<ReasonConfig, Guid>, IReasonConfigRepository
    {
        public ReasonConfigRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
