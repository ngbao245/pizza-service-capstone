using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IWorkingSlotRegisterService : IDomainService
    {
        Task<Guid> RegisterWorkingSlotAsync(DateOnly workingDate, Guid staffId, Guid workingSlotId);
        Task UpdateStatusToApprovedAsync(Guid id);
        Task UpdateStatusToRejectedAsync(Guid id);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
    }
}
