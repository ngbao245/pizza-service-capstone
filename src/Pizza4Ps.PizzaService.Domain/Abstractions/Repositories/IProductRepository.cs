using Pizza4Ps.PizzaService.Domain.Entities;
using StructureCodeSolution.Domain.Abstractions.Repositories.RepositoryBase;

namespace StructureCodeSolution.Domain.Abstractions.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
    }
}
