using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Application.Models;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Queries.GetProduct
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, GetListProductQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetListProductQueryHandler(IMapper mapper
            , IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetListProductQueryResponse> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            var entities = await _productRepository.GetListAsNoTracking(
                x => request.Name == null || x.Name.Contains(request.Name)
                && request.Description == null || x.Description.Contains(request.Description)
                && request.Price == null || x.Price == request.Price)
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ProductDto>>(entities);
            var totalCount = await _productRepository.CountAsync(
                x => request.Name == null || x.Name.Contains(request.Name)
                && request.Description == null || x.Description.Contains(request.Description)
                && request.Price == null || x.Price == request.Price);
            return new GetListProductQueryResponse(result, totalCount);
        }
    }
}
