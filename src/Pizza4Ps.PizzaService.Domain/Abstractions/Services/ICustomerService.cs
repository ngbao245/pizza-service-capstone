namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface ICustomerService
	{
		Task<Guid> CreateAsync(string fullName, string phone);
		Task<Guid> UpdateAsync(Guid id, string fullName, string phone);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
