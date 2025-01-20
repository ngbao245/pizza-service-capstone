using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOption
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductOptionQuery, PaginatedResultDto<ProductOptionDto>>
	{
        private readonly IMapper _mapper;
        private readonly IProductOptionRepository _productOptionRepository;

        public GetListProductQueryHandler(IMapper mapper, IProductOptionRepository productOptionRepository)
        {
            _mapper = mapper;
            _productOptionRepository = productOptionRepository;
        }

        public async Task<PaginatedResultDto<ProductOptionDto>> Handle(GetListProductOptionQuery request, CancellationToken cancellationToken)
        {
            var query = _productOptionRepository.GetListAsNoTracking(
                x => (request.ProductId == null || x.ProductId == request.ProductId)
                && (request.OptionId == null || x.OptionId == request.OptionId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.ProductOptionErrorConstant.PRODUCTOPTION_NOT_FOUND);
            var result = _mapper.Map<List<ProductOptionDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ProductOptionDto>(result, totalCount);
        }
    }
}
