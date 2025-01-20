using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.CreateWorkingTime
{
    public class CreateWorkingTimeCommand : IRequest<ResultDto<Guid>>
	{
        public int DayOfWeek { get; set; }
        public string ShiftCode { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
