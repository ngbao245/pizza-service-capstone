using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOptionIgnoreQueryFilter
{
    public class GetListOptionIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOptionIgnoreQueryFilterQuery, PaginatedResultDto<OptionDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOptionRepository _optionRepository;

		public GetListOptionIgnoreQueryFilterQueryHandler(IMapper mapper, IOptionRepository optionRepository)
		{
			_mapper = mapper;
			_optionRepository = optionRepository;
		}

		public async Task<PaginatedResultDto<OptionDto>> Handle(GetListOptionIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _optionRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.Name == null || x.Name.Contains(request.Name))
					&& (request.Description == null || x.Description.Contains(request.Description))
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OptionDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OptionDto>(result, totalCount);
		}
	}
}
