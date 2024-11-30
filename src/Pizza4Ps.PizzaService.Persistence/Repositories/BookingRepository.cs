using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class BookingRepository : RepositoryBase<Booking, Guid>, IBookingRepository
    {
        public BookingRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
