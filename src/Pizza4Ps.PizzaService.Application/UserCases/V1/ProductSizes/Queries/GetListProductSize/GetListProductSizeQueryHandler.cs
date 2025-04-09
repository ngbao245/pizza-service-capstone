using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetListProductSize
{
    public class GetListProductSizeQueryHandler : IRequestHandler<GetListProductSizeQuery, PaginatedResultDto<ProductSizeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductSizeRepository _productSizeRepository;

        public GetListProductSizeQueryHandler(IMapper mapper, IProductSizeRepository productSizeRepository)
        {
            _mapper = mapper;
            _productSizeRepository = productSizeRepository;
        }

        public async Task<PaginatedResultDto<ProductSizeDto>> Handle(GetListProductSizeQuery request, CancellationToken cancellationToken)
        {
            var query = _productSizeRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name == request.Name)
                && (request.Diameter == null || x.Diameter == request.Diameter)
                && (request.Description == null || x.Description == request.Description)
                && (request.ProductId == null || x.ProductId == request.ProductId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ProductSizeDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ProductSizeDto>(result, totalCount);
        }
    }
}
