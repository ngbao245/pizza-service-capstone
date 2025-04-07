using Hangfire;
using Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs;

namespace Pizza4Ps.PizzaService.Infrastructure.Services.BackgroundJobs
{
    public class JobManager : IJobManager
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public JobManager(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
            //_dailyWorkJob = dailyWorkJob;
            //_monthlySalaryJob = monthlySalaryJob;
        }

        public void ScheduleJobs()
        {
            //RecurringJob.AddOrUpdate("daily-work", () => _dailyWorkJob.Execute(), Cron.Daily);
            //RecurringJob.AddOrUpdate("monthly-salary", () => _monthlySalaryJob.Execute(), Cron.Monthly);
        }
    }
}
