using AutoMapper;
using Azure;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Repositories;

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
            if (!Enum.TryParse(request.Type, true, out ZoneTypeEnum zoneType))
            {
                throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.INVALID_ZONE_TYPE);
            }
            var result = await _zoneService.CreateAsync(
                request.Name,
                request.Description,
                zoneType);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
