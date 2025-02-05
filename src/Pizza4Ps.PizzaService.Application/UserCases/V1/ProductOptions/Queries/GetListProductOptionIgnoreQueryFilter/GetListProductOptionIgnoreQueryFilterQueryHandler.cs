using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOptionIgnoreQueryFilter
{
    public class GetListProductOptionIgnoreQueryFilterQueryHandler : IRequestHandler<GetListProductOptionIgnoreQueryFilterQuery, PaginatedResultDto<ProductOptionDto>>
	{
		private readonly IMapper _mapper;
		private readonly IProductOptionRepository _ProductOptionRepository;

		public GetListProductOptionIgnoreQueryFilterQueryHandler(IMapper mapper, IProductOptionRepository ProductOptionRepository)
		{
			_mapper = mapper;
			_ProductOptionRepository = ProductOptionRepository;
		}

		public async Task<PaginatedResultDto<ProductOptionDto>> Handle(GetListProductOptionIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _ProductOptionRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.ProductId == null || x.ProductId == request.ProductId)
					&& (request.OptionId == null || x.OptionId == request.OptionId)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<ProductOptionDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<ProductOptionDto>(result, totalCount);
		}
	}
}
