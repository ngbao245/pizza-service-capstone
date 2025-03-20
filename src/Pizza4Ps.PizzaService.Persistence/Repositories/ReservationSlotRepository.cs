using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ReservationSlotRepository : RepositoryBase<ReservationSlot, Guid>, IReservationSlotRepository
    {
        public ReservationSlotRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
