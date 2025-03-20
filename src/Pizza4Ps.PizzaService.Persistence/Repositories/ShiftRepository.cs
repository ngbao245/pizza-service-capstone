using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ShiftRepository : RepositoryBase<Shift, Guid>, IShiftRepository
    {
        public ShiftRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
