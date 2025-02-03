using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.UpdateWorkingTime
{
	public class UpdateWorkingTimeCommandHandler : IRequestHandler<UpdateWorkingTimeCommand>
	{
		private readonly IWorkingTimeService _workingtimeService;

		public UpdateWorkingTimeCommandHandler(IWorkingTimeService workingtimeService)
		{
			_workingtimeService = workingtimeService;
		}

		public async Task Handle(UpdateWorkingTimeCommand request, CancellationToken cancellationToken)
		{
			var result = await _workingtimeService.UpdateAsync(
				request.Id!.Value,
				request.DayOfWeek,
				request.ShiftCode,
				request.Name,
				request.StartTime,
				request.EndTime);
		}
	}
}
