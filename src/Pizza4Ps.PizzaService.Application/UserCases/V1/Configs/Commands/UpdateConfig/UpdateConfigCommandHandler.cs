using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Configs.Commands.UpdateConfig
{
    public class UpdateConfigCommandHandler : IRequestHandler<UpdateConfigCommand, ResultDto<Guid>>
    {
        private readonly IConfigService _configService;

        public UpdateConfigCommandHandler(IConfigService configService)
        {
            _configService = configService;
        }

        public async Task<ResultDto<Guid>> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
        {
            var result = await _configService.UpdateValueAsync(request.Id, request.Value);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
