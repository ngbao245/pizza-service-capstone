using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class FeedbackRepository : RepositoryBase<Feedback, Guid>, IFeedbackRepository
    {
        public FeedbackRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
