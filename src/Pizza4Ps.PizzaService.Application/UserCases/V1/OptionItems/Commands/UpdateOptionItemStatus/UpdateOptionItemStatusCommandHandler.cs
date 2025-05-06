using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.UpdateOptionItemStatus
{
    public class UpdateOptionItemStatusCommandHandler : IRequestHandler<UpdateOptionItemStatusCommand>
    {
        private readonly IOptionItemRepository _optionItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOptionItemStatusCommandHandler(
            IOptionItemRepository optionItemRepository,
            IUnitOfWork unitOfWork)
        {
            _optionItemRepository = optionItemRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateOptionItemStatusCommand request, CancellationToken cancellationToken)
        {
            var optionItem = await _optionItemRepository.GetSingleByIdAsync(request.Id!.Value);
            if (optionItem == null)
            {
                throw new NotFoundException($"Option item with id {request.Id} not found.");
            }
            // Validate product type
            if (!Enum.TryParse(request.OptionItemStatus, true, out OptionItemStatus optionItemStatus))
            {
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.INVALID_PRODUCT_STATUS);
            }
            optionItem.UpdateStatus(optionItemStatus);
            _optionItemRepository.Update(optionItem);   
            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
