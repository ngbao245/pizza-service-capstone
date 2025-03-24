using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class SwapWorkingSlotRepository : RepositoryBase<SwapWorkingSlot, Guid>, ISwapWorkingSlotRepository
    {
        public SwapWorkingSlotRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}