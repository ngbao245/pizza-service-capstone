using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pizza4Ps.PizzaService.Infrastructure.Abstractions.BackgroundJobs;

namespace Pizza4Ps.PizzaService.Infrastructure.DependencyInjection.Extentions
{
    public static class BackgroundJobAppBuilderExtentions
    {
        public static IApplicationBuilder UseScheduledBackgroundJobs(this IApplicationBuilder app)
        {
            // Sử dụng Hangfire Dashboard
            app.UseHangfireDashboard();

            // Kích hoạt JobScheduler để lập lịch các job định kỳ khi ứng dụng khởi động
            var jobScheduler = app.ApplicationServices.GetRequiredService<IJobManager>();
            jobScheduler.ScheduleJobs();

            return app;
        }
    }
}
