using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.UpdateOptionStatus
{
    public class UpdateOptionStatusCommandHandler : IRequestHandler<UpdateOptionStatusCommand>
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOptionStatusCommandHandler(IOptionRepository optionRepository, IUnitOfWork unitOfWork)
        {
            _optionRepository = optionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateOptionStatusCommand request, CancellationToken cancellationToken)
        {
            var option = await _optionRepository.GetSingleByIdAsync(request.Id!.Value);
            if (option == null)
            {
                throw new NotFoundException($"Option with id {request.Id} not found.");
            }
            // Validate product type
            if (!Enum.TryParse(request.OptionStatus, true, out OptionStatus optionStatus))
            {
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.INVALID_PRODUCT_STATUS);
            }
            option.UpdateStatus(optionStatus);
            _optionRepository.Update(option);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
