using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.AutoAssignZone
{
    public class AutoAssignZoneCommandHandler : IRequestHandler<AutoAssignZoneCommand>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneScheduleService _StaffZoneScheduleService;

        public AutoAssignZoneCommandHandler(IMapper mapper, IStaffZoneScheduleService StaffZoneScheduleService)
        {
            _mapper = mapper;
            _StaffZoneScheduleService = StaffZoneScheduleService;
        }

        public async Task Handle(AutoAssignZoneCommand request, CancellationToken cancellationToken)
        {
            await _StaffZoneScheduleService.AutoAssignZoneAsync(request.WorkingDate);
        }
    }
}
