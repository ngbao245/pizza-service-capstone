using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProductStatus
{
    public class UpdateProductStatusCommandHandler : IRequestHandler<UpdateProductStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public UpdateProductStatusCommandHandler(IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public async Task Handle(UpdateProductStatusCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetSingleByIdAsync(request.Id!.Value);
            if (product == null)
            {
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
            }
            // Validate product type
            if (!Enum.TryParse(request.ProductStatus, true, out ProductStatus productStatus))
            {
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.INVALID_PRODUCT_STATUS);
            }
            product.UpdateProductStatus(productStatus);
            _productRepository.Update(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);   
        }
    }
}
