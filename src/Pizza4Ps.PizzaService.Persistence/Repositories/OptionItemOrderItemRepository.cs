using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class OptionItemOrderItemRepository : RepositoryBase<OptionItemOrderItem, Guid>, IOptionItemOrderItemRepository
    {
        public OptionItemOrderItemRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
