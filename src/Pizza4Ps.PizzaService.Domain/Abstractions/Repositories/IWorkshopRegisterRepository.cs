using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories.RepositoryBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Repositories
{
    public interface IWorkshopRegisterRepository : IRepositoryBase<WorkshopRegister, Guid>
    {
    }
}
