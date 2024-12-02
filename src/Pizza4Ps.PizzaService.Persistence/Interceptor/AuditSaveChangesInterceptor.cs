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
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property(nameof(IDateTracking.CreatedDate)) != null)
                        entry.Property(nameof(IDateTracking.CreatedDate)).CurrentValue = DateTimeOffset.UtcNow;

                    if (entry.Property(nameof(IUserTracking.CreatedBy)) != null)
                        entry.Property(nameof(IUserTracking.CreatedBy)).CurrentValue = userId != null ? userId : null;
                }
                else if (entry.State == EntityState.Modified && entry.Property(nameof(ISoftDelete.IsDeleted)).IsModified == false)
                {
                    if (entry.Property(nameof(IDateTracking.ModifiedDate)) != null)
                        entry.Property(nameof(IDateTracking.ModifiedDate)).CurrentValue = DateTimeOffset.UtcNow;

                    if (entry.Property(nameof(IUserTracking.ModifiedBy)) != null)
                        entry.Property(nameof(IUserTracking.ModifiedBy)).CurrentValue = userId != null ? userId : null;
                }
                else if (entry.State == EntityState.Modified && entry.Property("IsDeleted").IsModified == true && (bool) entry.Property("IsDeleted").CurrentValue == true)
                {
                    if (entry.Property("DeletedBy") != null)
                        entry.Property("DeletedBy").CurrentValue = userId != null ? userId : null;
                    if (entry.Property("DeletedAt") != null)
                        entry.Property("DeletedAt").CurrentValue = DateTimeOffset.UtcNow;
                }
                else if (entry.State == EntityState.Modified && entry.Property("IsDeleted").IsModified == true && (bool) entry.Property("IsDeleted").CurrentValue == false)
                {
                    if (entry.Property("DeletedBy") != null)
                        entry.Property("DeletedBy").CurrentValue = null;
                    if (entry.Property("DeletedAt") != null)
                        entry.Property("DeletedAt").CurrentValue = null;
                }
            }

            // Gọi base logic
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
