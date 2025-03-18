using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZoneIgnoreQueryFilter
{
    public class GetListZoneIgnoreQueryFilterQueryHandler : IRequestHandler<GetListZoneIgnoreQueryFilterQuery, PaginatedResultDto<ZoneDto>>
	{
		private readonly IMapper _mapper;
		private readonly IZoneRepository _zoneRepository;

		public GetListZoneIgnoreQueryFilterQueryHandler(IMapper mapper, IZoneRepository zoneRepository)
		{
			_mapper = mapper;
			_zoneRepository = zoneRepository;
		}

		public async Task<PaginatedResultDto<ZoneDto>> Handle(GetListZoneIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _zoneRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.Name == null || x.Name.Contains(request.Name))
					&& (request.Description == null || x.Description.Contains(request.Description))
					&& (request.Status == null || x.Status == request.Status)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<ZoneDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<ZoneDto>(result, totalCount);
		}
	}
}
