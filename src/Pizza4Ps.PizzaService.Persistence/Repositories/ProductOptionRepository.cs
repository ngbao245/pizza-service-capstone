using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ProductOptionRepository : RepositoryBase<ProductOption, Guid>, IProductOptionRepository
    {
        public ProductOptionRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
