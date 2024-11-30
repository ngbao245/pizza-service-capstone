using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class TableRepository : RepositoryBase<Table, Guid>, ITableRepository
    {
        public TableRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
