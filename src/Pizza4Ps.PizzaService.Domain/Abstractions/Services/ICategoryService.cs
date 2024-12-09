namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<Guid> CreateAsync(string name, string description);
        Task<Guid> UpdateAsync(Guid id, string name, string description);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
