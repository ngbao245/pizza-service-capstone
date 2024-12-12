namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IOrderService
	{
		Task<Guid> CreateAsync(DateTimeOffset startTime, DateTimeOffset endTime, string? status, Guid orderInTableId);
		Task<Guid> UpdateAsync(Guid id, DateTimeOffset startTime, DateTimeOffset endTime, string? status, Guid orderInTableId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
