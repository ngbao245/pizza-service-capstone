namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface ISwapWorkingSlotService
    {
        Task<Guid> CreateAsync(DateOnly workingDateFrom, Guid employeeFromId, Guid workingSlotFromId,
                                DateOnly workingDateTo, Guid employeeToId, Guid workingSlotToId);
        Task UpdateStatusToPendingApproveAsync(Guid id);
        Task UpdateStatusToApprovedAsync(Guid id);
        Task UpdateStatusToRejectedAsync(Guid id);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
    }
}
