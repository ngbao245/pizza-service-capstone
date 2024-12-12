using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IZoneService
	{
		Task<Guid> CreateAsync(string name, int? capacity, string? description, ZoneTypeEnum status);
		Task<Guid> UpdateAsync(Guid id, string name, int? capacity, string? description, ZoneTypeEnum status);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
