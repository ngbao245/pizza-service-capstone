using Consul;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;
using System.Net;
using System.Reflection;
using System.Text;

namespace Pizza4Ps.PizzaService.API.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddSwaggerAuthUI(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
                //Pizza4Ps.PizzaService
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });
        }
        public static void AddServiceDiscoveryConsul(this IServiceCollection services)
        {
            services.AddServiceDiscovery(o => o.UseConsul());
        }
        public static void AddServicePizzaClient(this IServiceCollection services)
        {
            // Other configurations...

            // Register service with Consul
            var consulClient = new HttpClient();
            var registration = new
            {
                Name = Environment.GetEnvironmentVariable("SERVICE_NAME"),
                Address = Dns.GetHostName(),
                Port = int.Parse(Environment.GetEnvironmentVariable("SERVICE_PORT")),
                Check = new
                {
                    Http = $"http://{Dns.GetHostName()}:{Environment.GetEnvironmentVariable("SERVICE_PORT")}/health",
                    Interval = "10s"
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");
            var response = consulClient.PutAsync($"{Environment.GetEnvironmentVariable("CONSUL_ADDRESS")}/v1/agent/service/register", content).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Service registered successfully with Consul");
            }
            else
            {
                Console.WriteLine("Failed to register service with Consul");
            }

            // Other configurations...
        }
    }
}
