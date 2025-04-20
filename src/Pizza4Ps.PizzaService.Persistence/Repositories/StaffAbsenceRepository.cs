using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class StaffAbsenceRepository : RepositoryBase<StaffAbsence, Guid>, IStaffAbsenceRepository
    {
        public StaffAbsenceRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
