namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IStaffZoneService
    {
        Task<Guid> CreateAsync(string note, Guid staffId, Guid zoneId);
        Task SyncStaffZonesAsync(DateOnly workingDate, Guid workingSlotId);
        Task<Guid> UpdateAsync(Guid id, string note, Guid staffId, Guid zoneId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
