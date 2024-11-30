using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class TableBookingRepository : RepositoryBase<TableBooking, Guid>, ITableBookingRepository
    {
        public TableBookingRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
