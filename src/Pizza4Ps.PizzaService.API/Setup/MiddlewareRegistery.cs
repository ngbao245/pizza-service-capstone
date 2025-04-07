using Pizza4Ps.PizzaService.API.Middlewares;
using Pizza4Ps.PizzaService.Infrastructure.DependencyInjection.Extentions;
using Pizza4Ps.PizzaService.Infrastructure.Services;

namespace Pizza4Ps.PizzaService.API.Setup
{
    public static class MiddlewareRegistery
    {
        public static IApplicationBuilder MiddlewareRegisteryMethod(this IApplicationBuilder app)
        {
            app.UseRouting();

            // Đăng ký CORS sau UseRouting
            app.UseCors("AllowAllOrigins");

            // Đăng ký xác thực và ủy quyền
            app.UseAuthentication();
            app.UseAuthorization();

            // Đăng ký middleware xử lý lỗi
            app.UseMiddleware<ExceptionHandler>();

            // Đăng ký các endpoint như SignalR hubs và controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/notificationHub");
                //endpoints.MapHub<NotificationHub>("/notificationHub");
                endpoints.MapControllers();
            });

            app.UseScheduledBackgroundJobs();

            // Đăng ký Swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "swagger"; // Cấu hình để Swagger UI chạy tại /swagger
            });

            return app;
        }
    }
}
