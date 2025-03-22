using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetProductSizeById
{
    public class GetProductSizeByIdQueryHandler : IRequestHandler<GetProductSizeByIdQuery, ProductSizeDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductSizeRepository _productRepository;

        public GetProductSizeByIdQueryHandler(IMapper mapper, IProductSizeRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductSizeDto> Handle(GetProductSizeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<ProductSizeDto>(entity);
            return result;
        }
    }
}
