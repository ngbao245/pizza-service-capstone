using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.CreateWorkingTime
{
	public class CreateWorkingTimeCommandHandler : IRequestHandler<CreateWorkingTimeCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IWorkingTimeService _WorkingTimeService;

		public CreateWorkingTimeCommandHandler(IMapper mapper, IWorkingTimeService WorkingTimeService)
		{
			_mapper = mapper;
			_WorkingTimeService = WorkingTimeService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateWorkingTimeCommand request, CancellationToken cancellationToken)
		{
			var result = await _WorkingTimeService.CreateAsync(
				request.DayOfWeek,
				request.ShiftCode,
				request.Name,
				request.StartTime,
				request.EndTime);
			return new ResultDto<Guid>
            {
				Id = result
			};
		}
	}
}
