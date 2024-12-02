using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification, Guid>, INotificationRepository
    {
        public NotificationRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
