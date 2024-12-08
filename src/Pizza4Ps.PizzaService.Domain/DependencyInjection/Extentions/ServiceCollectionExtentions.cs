using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pizza4Ps.PizzaService.Domain.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(AssemblyReference)) // Chỉ định assembly chứa các dịch vụ
                .AddClasses(classes => classes.InNamespaces("Domain.Services")) // Chỉ các lớp trong namespace của bạn
                .AsImplementedInterfaces() // Đăng ký như các interface mà chúng triển khai
                .WithTransientLifetime()); // Sử dụng Lifetime mà bạn muốn (Transient, Scoped, Singleton)
            return services;
        }

        //public static void AddDomainServices(this IServiceCollection services)
        //{
        //    var domainServiceTypes = AssemblyReference.Assembly.GetTypes()
        //        .Where(t => t.IsClass && !t.IsAbstract && t.Namespace?.Contains("Domain.Services") == true)
        //        .ToList();

        //    foreach (var serviceType in domainServiceTypes)
        //    {
        //        services.AddTransient(serviceType); // Hoặc AddScoped, AddSingleton tùy theo yêu cầu
        //    }
        //}
    }
}
