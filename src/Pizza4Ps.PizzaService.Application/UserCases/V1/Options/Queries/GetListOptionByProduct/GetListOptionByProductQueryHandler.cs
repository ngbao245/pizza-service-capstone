using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOptionByProduct
{
    public class GetListOptionByProductQueryHandler : IRequestHandler<GetListOptionByProductQuery, PaginatedResultDto<OptionMenuDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListOptionByProductQueryHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResultDto<OptionMenuDto>> Handle(
                    GetListOptionByProductQuery request,
                    CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetSingleAsync(
                predicate: p => p.Id == request.ProductId,
                includeProperties: "ProductOptions.Option.OptionItems");

            var options = product.ProductOptions
                .Select(po => po.Option)
                .AsQueryable()
                .Where(o =>(request.Name == null || o.Name.Contains(request.Name))&&(request.Description == null || o.Description.Contains(request.Description)));

            var pagedOptions = options
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount)
                .Take(request.TakeCount)
                .ToList();

            var result = _mapper.Map<List<OptionMenuDto>>(pagedOptions);

            return new PaginatedResultDto<OptionMenuDto>(
                result,
                totalCount: options.Count()
            );
        }
    }
}
