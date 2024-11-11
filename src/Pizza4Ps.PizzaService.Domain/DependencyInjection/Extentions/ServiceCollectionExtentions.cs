using Microsoft.Extensions.DependencyInjection;
using StructureCodeSolution.Domain;

namespace Pizza4Ps.PizzaService.Domain.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            var domainServiceTypes = AssemblyReference.Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Namespace?.Contains("Domain.Services") == true)
                .ToList();

            foreach (var serviceType in domainServiceTypes)
            {
                services.AddTransient(serviceType); // Hoặc AddScoped, AddSingleton tùy theo yêu cầu
            }
        }
    }
}
