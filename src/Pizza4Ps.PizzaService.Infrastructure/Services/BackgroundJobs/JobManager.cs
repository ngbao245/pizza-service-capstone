using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Persistence;

namespace Pizza4Ps.PizzaService.Infrastructure.Services.BackgroundJobs
{
    public class JobManager : IJobManager
    {
        private readonly IBackgroundJobService _backgroundJobService;

        private readonly IConfigRepository _configRepository;
        private readonly IServiceScopeFactory _scopeFactory;
        public JobManager(
            IBackgroundJobService backgroundJobService,
            IConfigRepository configRepository,
            IServiceScopeFactory scopeFactory
            )
        {
            _backgroundJobService = backgroundJobService;
            _configRepository = configRepository;
            _scopeFactory = scopeFactory;
        }

        public async Task ScheduleJobs()
        {
            DateTime cutoffDate = await GetCutoffDate();
            DateTime executeTime = cutoffDate.AddMinutes(30);
            string cronSchedule = GetCronExpression(executeTime);

            //_backgroundJobService.RemoveRecurringJob("auto-assign-zone-job");
            _backgroundJobService.RecurJob<AssignZoneJob>(
                "job-auto-assign-zone",
                job => job.ExecuteAsync(),
            cronSchedule
            );
        }

        private async Task<DateTime> GetCutoffDate()
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            var configRepo = scope.ServiceProvider.GetRequiredService<IConfigRepository>();

            var configs = await db.Configs.ToListAsync();
            var config = await _configRepository.GetSingleAsync(x => x.ConfigType == ConfigType.REGISTRATION_CUTOFF_DAY);
            int configDay = int.Parse(config.Value);

            DateTime vietnamNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "SE Asia Standard Time");

            int daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)vietnamNow.DayOfWeek + 7) % 7;
            DateTime cutoffDay = vietnamNow.Date.AddDays(daysUntilNextMonday).AddDays(-configDay).Date;
            return cutoffDay.AddMinutes(30);
            //return new DateTime(cutoffDay.Year, cutoffDay.Month, cutoffDay.Day, 11, 13, 0);
        }

        private string GetCronExpression(DateTime cutoffDate)
        {
            int dayOfWeek = (int)cutoffDate.DayOfWeek;
            return $"{cutoffDate.Minute} {cutoffDate.Hour} * * {dayOfWeek}";
        }
    }
}
