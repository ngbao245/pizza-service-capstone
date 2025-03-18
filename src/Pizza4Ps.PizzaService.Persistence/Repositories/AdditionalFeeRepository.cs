using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class AdditionalFeeRepository : RepositoryBase<AdditionalFee, Guid>, IAdditionalFeeRepository
    {
        public AdditionalFeeRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
