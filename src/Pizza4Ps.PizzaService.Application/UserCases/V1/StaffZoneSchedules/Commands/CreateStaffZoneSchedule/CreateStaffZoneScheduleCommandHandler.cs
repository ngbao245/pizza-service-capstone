using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.CreateStaffZoneSchedule
{
    public class CreateStaffZoneScheduleCommandHandler : IRequestHandler<CreateStaffZoneScheduleCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneScheduleService _StaffZoneScheduleService;

        public CreateStaffZoneScheduleCommandHandler(IMapper mapper, IStaffZoneScheduleService StaffZoneScheduleService)
        {
            _mapper = mapper;
            _StaffZoneScheduleService = StaffZoneScheduleService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateStaffZoneScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffZoneScheduleService.CreateAsync(
                request.DayofWeek,
                request.ShiftStart,
                request.ShiftEnd,
                request.Note,
                request.StaffId,
                request.ZoneId,
                request.WorkingTimeId

                );
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
