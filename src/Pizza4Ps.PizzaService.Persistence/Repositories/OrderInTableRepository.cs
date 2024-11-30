using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class OrderInTableRepository : RepositoryBase<OrderInTable, Guid>, IOrderInTableRepository
    {
        public OrderInTableRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
