using Hangfire;
using Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs;
using System.Linq.Expressions;

namespace Pizza4Ps.PizzaService.Infrastructure.Services.BackgroundJobs
{
    public class BackgroundJobService : IBackgroundJobService
    {
        public void EnqueueJob<T>(Expression<Action<T>> methodCall)
        {
            BackgroundJob.Enqueue<T>(methodCall);
        }

        public string ScheduleJob<T>(Expression<Action<T>> methodCall, TimeSpan delay)
        {
            return BackgroundJob.Schedule<T>(methodCall, delay);
        }

        public void RecurJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression)
        {
            RecurringJob.AddOrUpdate<T>(jobId, methodCall, cronExpression);
        }

        public bool DeleteJob(string jobId)
        {
            return BackgroundJob.Delete(jobId);
        }

        public bool RemoveRecurringJob(string jobId)
        {
            RecurringJob.RemoveIfExists(jobId);
            return true;
        }
    }
}
