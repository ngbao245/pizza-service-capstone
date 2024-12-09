using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IMapper mapper
            , IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetSingleByIdAsync(request.Id);
            var result = _mapper.Map<ProductDto>(entity);
            return new GetProductByIdQueryResponse
            {
                product = result
            };
        }
    }
}
