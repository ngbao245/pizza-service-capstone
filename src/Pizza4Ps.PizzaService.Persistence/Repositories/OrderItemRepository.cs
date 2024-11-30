using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem, Guid>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
