namespace Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs
{
    public interface IJobManager
    {
        Task ScheduleJobs();
    }
}
