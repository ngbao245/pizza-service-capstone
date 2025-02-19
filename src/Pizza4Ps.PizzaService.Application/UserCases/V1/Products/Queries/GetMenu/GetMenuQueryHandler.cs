using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetMenu
{
    public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, PaginatedResultDto<ProductMenuDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetMenuQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<PaginatedResultDto<ProductMenuDto>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            var query = _productRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                && (request.Price == null || x.Price == request.Price)
                && (request.CategoryId == null || x.CategoryId == request.CategoryId)
                && (request.ProductType == null || x.ProductType == request.ProductType),
                includeProperties: "Category,ProductOptions.Option.OptionItems"
            );

            var entities = await query.OrderBy(request.SortBy).Skip(request.SkipCount).Take(request.TakeCount).ToListAsync() ;

            var result = _mapper.Map<List<ProductMenuDto>>(entities);

            var totalCount = await query.CountAsync();

            return new PaginatedResultDto<ProductMenuDto>(result, totalCount);
        }
    }
}