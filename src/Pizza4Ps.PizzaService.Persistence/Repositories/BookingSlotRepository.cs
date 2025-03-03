using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class BookingSlotRepository : RepositoryBase<BookingSlot, Guid>, IBookingSlotRepository
    {
        public BookingSlotRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
