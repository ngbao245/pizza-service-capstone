using System.Linq.Expressions;

namespace Pizza4Ps.PizzaService.Infrastructure.Abstractions.BackgroundJobs
{
    public interface IBackgroundJobService
    {
        void EnqueueJob<T>(Expression<Action<T>> methodCall);
        void ScheduleJob<T>(Expression<Action<T>> methodCall, TimeSpan delay);
        void RecurJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression);
    }
}
