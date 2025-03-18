using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IZoneService : IDomainService
    {
		Task<Guid> CreateAsync(string name, string description);
		Task<Guid> UpdateAsync(Guid id, string name, string description, ZoneTypeEnum status);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
