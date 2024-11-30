using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public UnitOfWork(ApplicationDBContext context)
            => _context = context;

        async ValueTask IAsyncDisposable.DisposeAsync()
            => await _context.DisposeAsync();

        public DbContext GetDbContext()
            => _context;

        public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync();
    }
}
