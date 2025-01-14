using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizza4Ps.PizzaService.Application.Contract.Abstractions.Services.IExternalServiceBase;
using Pizza4Ps.PizzaService.Infrastructure.Abstractions.BackgroundJobs;
using Pizza4Ps.PizzaService.Infrastructure.Services.BackgroundJobs;
using Pizza4Ps.PizzaService.Infrastructure.Services.ExternalServiceBase;

namespace Pizza4Ps.PizzaService.Infrastructure.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddHangfireServices(this IServiceCollection services)
        {
            // Thêm Hangfire
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("Hangfire");
            services.AddHangfire(config => config.UseSqlServerStorage(connectionString));
            services.AddHangfireServer();
            return services;
        }

        public static IServiceCollection AddBackgroundJobServices(this IServiceCollection services)
        {
            services.AddSingleton<IBackgroundJobService, BackgroundJobService>();
            services.AddSingleton<IJobManager, JobManager>();
            // Đăng ký và khởi tạo các job định kỳ
            // jobManager.ScheduleJobs();
            return services;
        }

        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            //Đăng ký tất cả các lớp kế thừa IExternalService hoặc ExternalService
            services.Scan(scan => scan
                .FromAssemblies(AssemblyReference.Assembly) // Hoặc chỉ định Assembly cụ thể
                .AddClasses(classes => classes.AssignableTo<IExternalService>()) // Tìm các class kế thừa IDomainService
                .AsImplementedInterfaces() // Đăng ký dưới dạng interface đã implement
                .WithScopedLifetime()); // Hoặc .WithSingletonLifetime() hoặc .WithTransientLifetime()
            return services;
        }

        public static IServiceCollection AddHttpClientSendApiService(this IServiceCollection services)
        {
            services.AddHttpClient<ISendApiService, SendApiService>();
            return services;
        }
    }
}
