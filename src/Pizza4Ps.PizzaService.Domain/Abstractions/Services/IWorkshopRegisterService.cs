using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IWorkshopRegisterService : IDomainService
    {
        Task<Guid> RegisterAsync(WorkshopRegister workshopRegister, List<WorkshopPizzaRegister> workshopPizzaRegisters, List<WorkshopPizzaRegisterDetail> workshopPizzaRegisterDetails);
    }
}
