using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.DependencyInjection.Options;
using System.Reflection;

namespace Pizza4Ps.PizzaService.Domain.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // Đăng ký tất cả các lớp kế thừa IDomainService hoặc DomainService
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly()) // Hoặc chỉ định Assembly cụ thể
                .AddClasses(classes => classes.AssignableTo<IDomainService>()) // Tìm các class kế thừa IDomainService
                .AsImplementedInterfaces() // Đăng ký dưới dạng interface đã implement
                .WithScopedLifetime()); // Hoặc .WithSingletonLifetime() hoặc .WithTransientLifetime()
            return services;
        }

        public static IServiceCollection AddVietQRConfig(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var vietQRConfig = new VietQRConfig();
            configuration.GetSection(nameof(VietQRConfig)).Bind(vietQRConfig);

            // Đăng ký VietQRConfig dưới dạng Singleton
            services.AddSingleton(vietQRConfig);

            return services;
        }
    }
}
