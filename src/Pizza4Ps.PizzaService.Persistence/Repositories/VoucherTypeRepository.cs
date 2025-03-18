using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class VoucherTypeRepository : RepositoryBase<VoucherType, Guid>, IVoucherTypeRepository
    {
        public VoucherTypeRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
