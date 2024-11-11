using StructureCodeSolution.Domain.Abstractions.Repositories.RepositoryBase;
using StructureCodeSolution.Domain.Entities.Product;

namespace StructureCodeSolution.Domain.Abstractions.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
    }
}
