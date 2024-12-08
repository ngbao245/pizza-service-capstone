using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Entities;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories.RepositoryBase;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Expressions;

namespace Pizza4Ps.PizzaService.Persistence
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>, IDisposable
        where TEntity : EntityBase<TKey>
    {
        private readonly ApplicationDBContext _dbContext;

        public RepositoryBase(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void Dispose() => _dbContext?.Dispose();

        public void Add(TEntity entity)
            => _dbContext.Add(entity);

        public void Delete(TEntity entity)
            => _dbContext.Set<TEntity>().Remove(entity);



        public IQueryable<TEntity> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>>? predicate = null,
            params Expression<Func<TEntity, object>>[]? includeProperties)
        {
            IQueryable<TEntity> items = _dbContext.Set<TEntity>().AsNoTracking(); // Importance Always include AsNoTracking for Query Side
            if (predicate is not null)
                items = items.Where(predicate);
            if (includeProperties != null)
                foreach (var includeProperty in includeProperties)
                    items = items.Include(includeProperty);
            return items;
        }

        public IQueryable<TEntity> GetAsTrackingAsync(Expression<Func<TEntity, bool>>? predicate = null,
            params Expression<Func<TEntity, object>>[]? includeProperties)
        {
            IQueryable<TEntity> items = _dbContext.Set<TEntity>().AsTracking(); // Importance Always include AsNoTracking for Query Side
            if (predicate is not null)
                items = items.Where(predicate);
            if (includeProperties != null)
                foreach (var includeProperty in includeProperties)
                    items = items.Include(includeProperty);
            return items;
        }

        public async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
            => await GetAsTrackingAsync(null, includeProperties)
            .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);


        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
            => await GetAsTrackingAsync(null, includeProperties)
            .SingleOrDefaultAsync(predicate, cancellationToken);

        public void RemoveMultiple(List<TEntity> entities)
            => _dbContext.RemoveRange(entities);

        public void Update(TEntity entity)
            => _dbContext.Update(entity);

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> items = _dbContext.Set<TEntity>().AsNoTracking(); // Importance Always include AsNoTracking for Query Side
            if (predicate is not null)
                items = items.Where(predicate);
            return await items.CountAsync();
        }

        public void SoftDelete(TEntity entity)
        {
            if (entity is not ISoftDelete )
            {
                throw new BusinessException("This function is not implement");
            }
            var entityType = typeof(TEntity);
            // Lấy thông tin người dùng hiện tại
            // Tìm thuộc tính IsDeleted
            var isDeletedProperty = entityType.GetProperty("IsDeleted");
            if (isDeletedProperty != null && isDeletedProperty.PropertyType == typeof(bool))
            {
                isDeletedProperty.SetValue(entity, true);
            }
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void Restore(TEntity entity)
        {
            if (entity is not ISoftDelete)
            {
                throw new BusinessException("This function is not implement");
            }
            var entityType = typeof(TEntity);
            var isDeletedProperty = entityType.GetProperty("IsDeleted");
            if (isDeletedProperty != null && isDeletedProperty.PropertyType == typeof(bool))
            {
                isDeletedProperty.SetValue(entity, false);
            }
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void HardDelete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
