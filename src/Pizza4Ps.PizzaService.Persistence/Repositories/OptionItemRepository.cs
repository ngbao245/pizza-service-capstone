using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class OptionItemRepository : RepositoryBase<OptionItem, Guid>, IOptionItemRepository
    {
        public OptionItemRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
