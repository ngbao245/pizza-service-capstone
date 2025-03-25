namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface ISwapWorkingSlotService
    {
        Task<Guid> CreateAsync(Guid employeeFromId, Guid employeeToId, Guid workingSlotFromId, Guid workingSlotToId);
        Task UpdateStatusToPendingApproveAsync(Guid id);
        Task UpdateStatusToApprovedAsync(Guid id);
        Task UpdateStatusToRejectedAsync(Guid id);
    }
}
