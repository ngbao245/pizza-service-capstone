using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.CreateStaffZone
{
    public class CreateStaffZoneCommandHandler : IRequestHandler<CreateStaffZoneCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneService _StaffZoneService;

        public CreateStaffZoneCommandHandler(IMapper mapper, IStaffZoneService StaffZoneService)
        {
            _mapper = mapper;
            _StaffZoneService = StaffZoneService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateStaffZoneCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffZoneService.CreateAsync(
                request.Note,
                request.StaffId,
                request.ZoneId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
