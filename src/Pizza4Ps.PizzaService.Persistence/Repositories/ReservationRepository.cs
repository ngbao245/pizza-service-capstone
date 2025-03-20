using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class ReservationRepository : RepositoryBase<Reservation, Guid>, IReservationRepository
    {
        public ReservationRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
