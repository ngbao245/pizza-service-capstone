using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IStaffAbsenceService
    {
        Task<Guid> CreateAsync(Guid staffId, Guid workingSlotId, DateOnly absentDate);
        //Task<Guid> UpdateAsync(Guid id, string fullName, string phone, string email, StaffTypeEnum staffType, StaffStatusEnum status);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
