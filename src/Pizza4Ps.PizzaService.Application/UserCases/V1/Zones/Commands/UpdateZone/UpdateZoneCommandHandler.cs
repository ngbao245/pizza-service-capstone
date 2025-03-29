using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.UpdateZone
{
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand>
    {
        private readonly IZoneService _zoneService;

        public UpdateZoneCommandHandler(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        public async Task Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse(request.Type, true, out ZoneTypeEnum zoneType))
            {
                throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.INVALID_ZONE_TYPE);
            }

            var result = await _zoneService.UpdateAsync(
                request.Id!.Value,
                request.Name,
                request.Description,
                zoneType);
        }
    }
}
