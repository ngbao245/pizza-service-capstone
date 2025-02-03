using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

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
            var result = await _zoneService.UpdateAsync(
                request.Id!.Value,
                request.Name,
                request.Capacity,
                request.Description,
                request.Status);
        }
    }
}
