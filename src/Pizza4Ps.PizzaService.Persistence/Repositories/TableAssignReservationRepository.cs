using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class TableAssignReservationRepository : RepositoryBase<TableAssignReservation, Guid>, ITableAssignReservationRepository
    {
        public TableAssignReservationRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
