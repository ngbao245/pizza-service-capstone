using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class OptionRepository : RepositoryBase<Option, Guid>, IOptionRepository
    {
        public OptionRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
