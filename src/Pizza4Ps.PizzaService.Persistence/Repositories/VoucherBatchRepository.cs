using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class VoucherBatchRepository : RepositoryBase<VoucherBatch, Guid>, IVoucherBatchRepository
    {
        public VoucherBatchRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
