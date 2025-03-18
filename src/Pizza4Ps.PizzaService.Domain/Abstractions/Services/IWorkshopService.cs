using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IWorkshopService : IDomainService
    {
        Task<Guid> CreateAsync(Workshop workshop, List<WorkshopFoodDetail> workshopFoodDetails);
    }
}
