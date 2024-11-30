using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories.RepositoryBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
    }
}
