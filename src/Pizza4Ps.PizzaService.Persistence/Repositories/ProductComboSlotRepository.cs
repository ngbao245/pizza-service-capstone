using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ProductComboSlotRepository : RepositoryBase<ProductComboSlot, Guid>, IProductComboSlotRepository
    {
        public ProductComboSlotRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
