using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItemIgnoreQueryFilter
{
    public class GetListOptionItemIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOptionItemIgnoreQueryFilterQuery, PaginatedResultDto<OptionItemDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemRepository _optionitemRepository;

		public GetListOptionItemIgnoreQueryFilterQueryHandler(IMapper mapper, IOptionItemRepository optionitemRepository)
		{
			_mapper = mapper;
			_optionitemRepository = optionitemRepository;
		}

		public async Task<PaginatedResultDto<OptionItemDto>> Handle(GetListOptionItemIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _optionitemRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.Name == null || x.Name.Contains(request.Name))
					&& (request.AdditionalPrice == null || x.AdditionalPrice == request.AdditionalPrice)
					&& (request.OptionId == null || x.OptionId == request.OptionId)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OptionItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OptionItemDto>(result, totalCount);
		}
	}
}
