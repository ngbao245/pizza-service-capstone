using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ProductComboSlotItemRepository : RepositoryBase<ProductComboSlotItem, Guid>, IProductComboSlotItemRepository
    {
        public ProductComboSlotItemRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
