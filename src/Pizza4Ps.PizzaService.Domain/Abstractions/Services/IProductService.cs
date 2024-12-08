namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IProductService
    {
        Task<Guid> CreateAsync(string name, decimal price, string description, Guid categoryId);
        Task<Guid> UpdateAsync(Guid id, string name, decimal price, string description, Guid categoryId);
        Task RemoveAsync(Guid id);
        Task SetIsDeleteAsync(Guid id);
    }
}
