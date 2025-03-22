using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IStaffService : IDomainService
    {
        Task<Guid> CreateAsync(string fullName, string phone, string email, StaffTypeEnum staffType, StaffStatusEnum status);
        Task<Guid> UpdateAsync(Guid id, string fullName, string phone, string email, StaffTypeEnum staffType, StaffStatusEnum status);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
