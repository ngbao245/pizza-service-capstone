using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Configs.Commands.UpdateConfig
{
    public class UpdateConfigCommandHandler : IRequestHandler<UpdateConfigCommand>
    {
        private readonly IConfigService _configService;

        public UpdateConfigCommandHandler(IConfigService configService)
        {
            _configService = configService;
        }

        public async Task Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
        {
            var result = await _configService.UpdateAsync(
                request.Id!.Value,
                request.ConfigType,
                request.Key,
                request.Value);
        }
    }
}
