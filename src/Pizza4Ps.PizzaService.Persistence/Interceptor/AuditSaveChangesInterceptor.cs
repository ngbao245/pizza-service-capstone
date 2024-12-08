using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pizza4Ps.PizzaService.Domain.Abstractions.Entities;
using Pizza4Ps.PizzaService.Persistence.Helpers;

namespace Pizza4Ps.PizzaService.Persistence.Intercepter
{
    public class AuditSaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public AuditSaveChangesInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAcessor = httpContextAccessor;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if (context == null) return await base.SavingChangesAsync(eventData, result, cancellationToken);

            // Lấy thông tin người dùng hiện tại
            var userId = _httpContextAcessor?.HttpContext?.GetCurrentUserId();

            // Duyệt qua các thay đổi trong ChangeTracker
            foreach (var entry in context.ChangeTracker.Entries())
            {
                var now = DateTimeOffset.UtcNow;

                if (entry.Entity is IDateTracking dateTracking)
                {
                    if (entry.State == EntityState.Added)
                        dateTracking.CreatedDate = now;
                    else if (entry.State == EntityState.Modified && !entry.Property(nameof(ISoftDelete.IsDeleted)).IsModified)
                        dateTracking.ModifiedDate = now;
                }

                if (entry.Entity is IUserTracking userTracking)
                {
                    if (entry.State == EntityState.Added)
                        userTracking.CreatedBy = userId;
                    else if (entry.State == EntityState.Modified && !entry.Property(nameof(ISoftDelete.IsDeleted)).IsModified)
                        userTracking.ModifiedBy = userId;
                }

                if (entry.Entity is ISoftDelete softDelete && entry.State == EntityState.Modified && entry.Property(nameof(ISoftDelete.IsDeleted)).IsModified)
                {
                    var isDeleted = (bool) entry.Property(nameof(ISoftDelete.IsDeleted)).CurrentValue;
                    softDelete.DeletedAt = isDeleted ? now : (DateTimeOffset?)null;
                    softDelete.DeletedBy = isDeleted ? userId : null;
                }
            }


            // Gọi base logic
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
