using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AdditionalFees.Commands.CreateAdditionalFee
{
    public class CreateAdditionalFeeCommandHandler : IRequestHandler<CreateAdditionalFeeCommand, ResultDto<Guid>>
    {
        private readonly IAdditionalFeeService _additionalFeeService;

        public CreateAdditionalFeeCommandHandler(IAdditionalFeeService additionalFeeService)
        {
            _additionalFeeService = additionalFeeService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateAdditionalFeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _additionalFeeService.CreateAsync(
                request.Name,
                request.Description,
                request.Value,
                request.OrderId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
