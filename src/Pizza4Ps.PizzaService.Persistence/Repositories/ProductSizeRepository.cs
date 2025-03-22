using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ProductSizeRepository : RepositoryBase<ProductSize, Guid>, IProductSizeRepository
    {
        public ProductSizeRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}