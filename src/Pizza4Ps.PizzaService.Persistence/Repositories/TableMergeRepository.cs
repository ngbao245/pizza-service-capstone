using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class TableMergeRepository : RepositoryBase<TableMerge, Guid>, ITableMergeRepository
    {
        public TableMergeRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
