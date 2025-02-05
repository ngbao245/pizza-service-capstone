using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTimeIgnoreQueryFilter
{
    public class GetListWorkingTimeIgnoreQueryFilterQueryHandler : IRequestHandler<GetListWorkingTimeIgnoreQueryFilterQuery, PaginatedResultDto<WorkingTimeDto>>
	{
		private readonly IMapper _mapper;
		private readonly IWorkingTimeRepository _workingtimeRepository;

		public GetListWorkingTimeIgnoreQueryFilterQueryHandler(IMapper mapper, IWorkingTimeRepository workingtimeRepository)
		{
			_mapper = mapper;
			_workingtimeRepository = workingtimeRepository;
		}

		public async Task<PaginatedResultDto<WorkingTimeDto>> Handle(GetListWorkingTimeIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _workingtimeRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.DayOfWeek == null || x.DayOfWeek == request.DayOfWeek)
					&& (request.ShiftCode == null || x.ShiftCode.Contains(request.ShiftCode))
					&& (request.Name == null || x.Name.Contains(request.Name))
					&& (request.StartTime == null || x.StartTime == request.StartTime)
					&& (request.EndTime == null || x.EndTime == request.EndTime)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<WorkingTimeDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<WorkingTimeDto>(result, totalCount);
		}
	}
}
