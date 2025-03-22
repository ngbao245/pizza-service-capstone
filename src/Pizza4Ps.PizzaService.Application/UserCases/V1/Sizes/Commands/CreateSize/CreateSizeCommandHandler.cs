using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Sizes.Commands.CreateSize
{
    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ISizeService _sizeService;

        public CreateSizeCommandHandler(IMapper mapper, ISizeService sizeService)
        {
            _mapper = mapper;
            _sizeService = sizeService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateSizeCommand request, CancellationToken cancellationToken)
        {
            var result = await _sizeService.CreateAsync(
                request.Name,
                request.DiameterCm,
                request.Description
                );
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
