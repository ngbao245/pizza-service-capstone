using Hangfire.Dashboard;

namespace Pizza4Ps.PizzaService.Infrastructure.DependencyInjection.Extentions
{
    public class DashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context) => true; // Cho phép tất cả
    }
}
