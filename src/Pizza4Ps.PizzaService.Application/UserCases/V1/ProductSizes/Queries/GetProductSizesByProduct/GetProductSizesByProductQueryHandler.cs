using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetProductSizesByProduct
{
    public class GetProductSizesByProductQueryHandler : IRequestHandler<GetProductSizesByProductQuery, List<ProductSizeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductSizeRepository _productSizeRepository;

        public GetProductSizesByProductQueryHandler(IMapper mapper, IProductRepository productRepository, IProductSizeRepository productSizeRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productSizeRepository = productSizeRepository;
        }

        public async Task<List<ProductSizeDto>> Handle(GetProductSizesByProductQuery request, CancellationToken cancellationToken)
        {
            var productExists = await _productRepository.GetSingleByIdAsync(request.ProductId);
            if (productExists == null)
            {
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
            }

            var productSizes = await _productSizeRepository.GetListAsNoTracking(
            ps => ps.ProductId == request.ProductId,
            includeProperties: "Recipes.Ingredient"
            ).ToListAsync(cancellationToken);


            if (!productSizes.Any())
            {
                return new List<ProductSizeDto>();
            }


            var result = _mapper.Map<List<ProductSizeDto>>(productSizes);
            return result;
        
        }
    }
}
