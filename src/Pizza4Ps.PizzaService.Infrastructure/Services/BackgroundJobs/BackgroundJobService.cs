using Hangfire;
using Pizza4Ps.PizzaService.Infrastructure.Abstractions.BackgroundJobs;
using System.Linq.Expressions;

namespace Pizza4Ps.PizzaService.Infrastructure.Services.BackgroundJobs
{
    public class BackgroundJobService : IBackgroundJobService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public BackgroundJobService(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public void EnqueueJob<T>(Expression<Action<T>> methodCall)
        {
            _backgroundJobClient.Enqueue(methodCall);
        }

        public void ScheduleJob<T>(Expression<Action<T>> methodCall, TimeSpan delay)
        {
            _backgroundJobClient.Schedule(methodCall, delay);
        }

        public void RecurJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression)
        {
            RecurringJob.AddOrUpdate(jobId, methodCall, cronExpression);
        }
    }
}
