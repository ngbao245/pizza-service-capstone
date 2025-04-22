using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProduct
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, PaginatedResultDto<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetListProductQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<PaginatedResultDto<ProductDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            List<ProductStatus>? productStatuses = new List<ProductStatus>();
            if (request.ProductStatuses != null)
            {
                foreach (var status in request.ProductStatuses)
                {
                    if (!string.IsNullOrEmpty(status))
                    {
                        if (!Enum.TryParse(status, true, out ProductStatus parsedStatus))
                        {
                            throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.INVALID_ORDER_ITEM_STATUS);
                        }
                        productStatuses.Add(parsedStatus);
                    }
                }
            }
            var query = _productRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                && (request.Price == null || x.Price == request.Price)
                && (productStatuses == null || productStatuses.Count == 0 || productStatuses.Contains(x.ProductStatus))
                && (request.CategoryId == null || x.CategoryId == request.CategoryId)
                && (request.ProductType == null || x.ProductType.Equals(request.ProductType)),
                includeProperties: request.IncludeProperties).AsSplitQuery();
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ProductDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ProductDto>(result, totalCount);
        }
    }
}
