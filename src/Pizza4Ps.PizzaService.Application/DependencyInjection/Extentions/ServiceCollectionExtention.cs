using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizza4Ps.PizzaService.Application.DependencyInjection.Options;
using Pizza4Ps.PizzaService.Application.Helpers;
using Pizza4Ps.PizzaService.Domain.DependencyInjection.Options;

namespace Pizza4Ps.PizzaService.Application.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddServicesFromAssembly(this IServiceCollection services)
        {
            //Assembly assembly = AssemblyReference.Assembly;
            //// Get all types from the assembly
            //var types = assembly.GetTypes();

            //// Iterate through all types in the assembly
            //foreach (var type in types)
            //{
            //    // Get the interfaces implemented by this type
            //    var interfaces = type.GetInterfaces();

            //    // Register services that follow the convention (e.g., classes implementing IService)
            //    foreach (var @interface in interfaces)
            //    {
            //        // If the type is a class, is not abstract, and implements an interface, register it.
            //        if (type.IsClass && !type.IsAbstract)
            //        {
            //            services.AddTransient(@interface, type); // Add to DI container (Scoped as an example)
            //        }
            //    }
            //}

            return services;
        }
        public static void AddMailService(this IServiceCollection services)
        {
            services.AddTransient<EmailService>();
        }
        public static void AddTwilioSMS(this IServiceCollection services)
        {
            services.AddHttpClient();       // Đăng ký IHttpClientFactory + default HttpClient
            services.AddTransient<SpeedSmsService>();
            services.AddTransient<TwilioSmsService>();
            services.AddTransient<EsmsService>();
        }
        public static IServiceCollection AddCloudinaryService(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var cloudinaryCongif = new CloudinaryConfig();
            configuration.GetSection(nameof(CloudinaryConfig)).Bind(cloudinaryCongif);

            // Parse từ CLOUDINARY_URL
            // Đăng ký Cloudinary vào DI container
            var cloudinary = new Cloudinary(new Account(
                cloudinaryCongif.CloudName,
                cloudinaryCongif.ApiKey,
                cloudinaryCongif.ApiSecret
            ));
            services.AddSingleton(cloudinary);
            return services;
        }
        public static void AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(AssemblyReference.Assembly);
        }
        public static void AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
        }
    }
}
