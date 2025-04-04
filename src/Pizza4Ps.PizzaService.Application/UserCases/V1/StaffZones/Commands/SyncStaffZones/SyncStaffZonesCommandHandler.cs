using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.SyncStaffZones
{
    public class SyncStaffZonesCommandHandler : IRequestHandler<SyncStaffZonesCommand>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneService _StaffZoneService;

        public SyncStaffZonesCommandHandler(IMapper mapper, IStaffZoneService staffZoneService)
        {
            _mapper = mapper;
            _StaffZoneService = staffZoneService;
        }

        public async Task Handle(SyncStaffZonesCommand request, CancellationToken cancellationToken)
        {
            await _StaffZoneService.SyncStaffZonesAsync(request.workingDate, request.workingSlotId);
        }
    }
}
