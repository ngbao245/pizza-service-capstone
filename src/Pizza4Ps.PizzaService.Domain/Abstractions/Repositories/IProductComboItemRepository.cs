using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories.RepositoryBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Repositories
{
    public interface IProductComboItemRepository : IRepositoryBase<ProductComboItem, Guid>
    {
    }
}
