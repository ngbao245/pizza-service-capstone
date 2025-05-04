using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IWorkshopService : IDomainService
    {
        Task<Guid> CreateAsync(Workshop workshop, List<WorkshopFoodDetail> workshopFoodDetails);
        Task StartRegisterWorkshop(Guid workshopId);
        Task CloseRegisterWorkshop(Guid workshopId);
        Task ReOpenToRegisterWorkshop(Guid workshopId, DateTime newEndRegisterDate);
        Task ForceOpenWorkshop(Guid workshopId);
    }
}
