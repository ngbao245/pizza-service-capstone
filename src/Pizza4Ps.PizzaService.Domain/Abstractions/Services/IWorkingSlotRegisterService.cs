using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IWorkingSlotRegisterService : IDomainService
    {
        Task<Guid> RegisterWorkingSlotAsync(Guid staffId, Guid workingSlotId);
        Task UpdateStatusToApprovedAsync(Guid id);
        Task UpdateStatusToRejectedAsync(Guid id);
    }
}
