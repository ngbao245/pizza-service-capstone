using System.Linq.Expressions;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Repositories.RepositoryBase
{
    public interface IRepositoryBase<TEntity, in TKey> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetAsTrackingAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<long> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void SoftDelete(TEntity entity);
        Task HardDeleteAsync(TKey id);
        Task RestoreAsync(TKey id);
        void RemoveMultiple(List<TEntity> entities);
    }
}
