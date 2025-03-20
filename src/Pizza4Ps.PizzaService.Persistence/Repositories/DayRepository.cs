using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class DayRepository : RepositoryBase<Day, Guid>, IDayRepository
    {
        public DayRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
