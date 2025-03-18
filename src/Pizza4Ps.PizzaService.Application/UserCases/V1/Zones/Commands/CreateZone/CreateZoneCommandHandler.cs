using AutoMapper;
using Azure;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.CreateZone
{
    public class CreateZoneCommandHandler : IRequestHandler<CreateZoneCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IZoneService _zoneService;

        public CreateZoneCommandHandler(IMapper mapper, IZoneService zoneService)
        {
            _mapper = mapper;
            _zoneService = zoneService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
        {
            var result = await _zoneService.CreateAsync(
                request.Name,
                request.Description);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
