using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.UpdateWorkingTime
{
    public class UpdateWorkingTimeCommand : IRequest
	{
		public Guid? Id { get; set; }
        public int DayOfWeek { get; set; }
        public string ShiftCode { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
