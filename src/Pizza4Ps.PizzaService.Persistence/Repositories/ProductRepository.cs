using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
    {
        public ProductRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
