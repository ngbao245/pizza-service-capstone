using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories.RepositoryBase;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;
using Pizza4Ps.PizzaService.Persistence.Intercepter;
using System.Text;
namespace Pizza4Ps.PizzaService.Persistence.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddSQLServerPersistence(this IServiceCollection services)
        {
            services.AddDbContextPool<DbContext, ApplicationDBContext>((provider, builder) =>
            {
                // dùng để lấy configuration từ appsetting và map vào object
                //var passwordValidatorOptions =
                //    services.BuildServiceProvider().GetRequiredService<IOptionsMonitor<PasswordValidatorOptions>>();
                //var auditableInterceptor = provider.GetService<UpdateAuditableEntitiesInterceptor>();
                var configuration = provider.GetRequiredService<IConfiguration>();
                // Lấy AuditSaveChangesInterceptor từ DI container
                var auditSaveChangesInterceptor = provider.GetRequiredService<AuditSaveChangesInterceptor>();
                builder
                    .UseSqlServer(
                    connectionString: configuration.GetConnectionString("MyDbContext"),
                    sqlServerOptionsAction: optionsBuilder
                        => optionsBuilder.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.GetName().Name))
                .AddInterceptors(auditSaveChangesInterceptor);
            });
        }
        public static void AddAuthService(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            // 2. Cấu hình Identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();

            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };    // Cấu hình lấy token từ query string khi dùng WebSocket
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // Nếu không tìm thấy token trong header, hãy thử lấy từ query string
                        var accessToken = context.Request.Query["access_token"];
                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
        public static IServiceCollection AddRepositoryAssembly(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(AssemblyReference.Assembly)
                .AddClasses(classes => classes.AssignableTo(typeof(IRepositoryBase<,>)))  // Điều kiện lọc các repository
                .AsImplementedInterfaces()  // Đăng ký chúng với interface tương ứng
                .WithTransientLifetime());
            // Các đăng ký khác
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            return services;
        }

        public static void AddInterceptorPersistence(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<AuditSaveChangesInterceptor>();
        }

    }
}
