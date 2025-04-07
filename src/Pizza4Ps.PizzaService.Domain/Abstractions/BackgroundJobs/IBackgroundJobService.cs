using System.Linq.Expressions;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs
{
    public interface IBackgroundJobService
    {
        void EnqueueJob<T>(Expression<Action<T>> methodCall);
        string ScheduleJob<T>(Expression<Action<T>> methodCall, TimeSpan delay);
        void RecurJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression);
        bool DeleteJob(string jobId);
        bool RemoveRecurringJob(string jobId);
    }
}
