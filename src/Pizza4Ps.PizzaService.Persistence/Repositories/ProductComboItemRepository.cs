using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ProductComboItemRepository : RepositoryBase<ProductComboItem, Guid>, IProductComboItemRepository
    {
        public ProductComboItemRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
