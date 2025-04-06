using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ReasonConfigs.Commands.CreateReasonConfig
{
    public class CreateReasonConfigCommandHandler : IRequestHandler<CreateReasonConfigCommand, ResultDto<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IReasonConfigRepository _reasonConfigRepository;

        public CreateReasonConfigCommandHandler(IReasonConfigRepository reasonConfigRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _reasonConfigRepository = reasonConfigRepository;
        }
        public async Task<ResultDto<Guid>> Handle(CreateReasonConfigCommand request, CancellationToken cancellationToken)
        {
            // Validate product type
            if (!Enum.TryParse(request.ReasonType, true, out ReasonConfigTypeEnum reasonType))
            {

                throw new BusinessException(BussinessErrorConstants.ReasonConfigErrorConstant.REASON_CONFIG_TYPE_INVALID);
            }
            var reasonConfig = new ReasonConfig(
                reason: request.Reason,
                reasonType: reasonType);
            _reasonConfigRepository.Add(reasonConfig);
            await _unitOfWork.SaveChangeAsync();
            return new ResultDto<Guid>
            {
                Id = reasonConfig.Id,
            };
        }
    }
}
