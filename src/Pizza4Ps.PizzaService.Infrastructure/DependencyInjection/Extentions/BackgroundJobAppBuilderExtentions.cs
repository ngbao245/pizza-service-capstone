using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs;

namespace Pizza4Ps.PizzaService.Infrastructure.DependencyInjection.Extentions
{
    public static class BackgroundJobAppBuilderExtentions
    {
        public static async Task<IApplicationBuilder> UseScheduledBackgroundJobs(this IApplicationBuilder app)
        {
            // Sử dụng Hangfire Dashboard
            //app.UseHangfireDashboard();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] {
                    new DashboardAuthorizationFilter()
                }
            });

            // Kích hoạt JobScheduler để lập lịch các job định kỳ khi ứng dụng khởi động
            using (var scope = app.ApplicationServices.CreateAsyncScope())
            {
                var jobScheduler = scope.ServiceProvider.GetRequiredService<IJobManager>();
                await jobScheduler.ScheduleJobs();
            }

            return app;
        }
    }
}
