using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class StaffRepository : RepositoryBase<Staff, Guid>, IStaffRepository
    {
        public StaffRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
