using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Models;
using StructureCodeSolution.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, PaginatedResult<GetProductQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IMapper mapper
            , IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<PaginatedResult<GetProductQueryResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var entities = await _productRepository.GetAsNoTrackingAsync(
                x => request.Name == null || x.Name.Contains(request.Name)
                && request.Description == null || x.Description.Contains(request.Description)
                && request.Price == null || x.Price == request.Price)
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<GetProductQueryResponse>>(entities);
            var totalCount = await _productRepository.CountAsync(
                x => request.Name == null || x.Name.Contains(request.Name)
                && request.Description == null || x.Description.Contains(request.Description)
                && request.Price == null || x.Price == request.Price);
            return new PaginatedResult<GetProductQueryResponse>(result, totalCount);
        }
    }
}
