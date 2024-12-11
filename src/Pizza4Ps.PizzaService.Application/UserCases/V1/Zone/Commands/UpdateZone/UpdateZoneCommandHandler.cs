using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zone.Commands.UpdateZone
{
	public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand, UpdateZoneCommandResponse>
	{
		private readonly IZoneService _zoneService;

		public UpdateZoneCommandHandler(IZoneService zoneService)
		{
			_zoneService = zoneService;
		}

		public async Task<UpdateZoneCommandResponse> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
		{
			var result = await _zoneService.UpdateAsync(request.Id, request.Name, request.Capacity, request.Description, request.Status);
			return new UpdateZoneCommandResponse
			{
				Id = result
			};
		}
	}
}
