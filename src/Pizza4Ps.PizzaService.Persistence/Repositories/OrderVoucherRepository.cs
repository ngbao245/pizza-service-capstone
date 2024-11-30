using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class OrderVoucherRepository : RepositoryBase<OrderVoucher, Guid>, IOrderVoucherRepository
    {
        public OrderVoucherRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
