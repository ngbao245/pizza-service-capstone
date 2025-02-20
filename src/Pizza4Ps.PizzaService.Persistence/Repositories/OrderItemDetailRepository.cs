using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class OrderItemDetailRepository : RepositoryBase<OrderItemDetail, Guid>, IOrderItemDetailRepository
    {
        public OrderItemDetailRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
