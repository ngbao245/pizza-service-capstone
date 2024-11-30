using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class VoucherRepository : RepositoryBase<Voucher, Guid>, IVoucherRepository
    {
        public VoucherRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
