using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetListTableBookingIgnoreQueryFilter
{
    public class GetListTableBookingIgnoreQueryFilterQueryHandler : IRequestHandler<GetListTableBookingIgnoreQueryFilterQuery, PaginatedResultDto<TableBookingDto>>
	{
		private readonly IMapper _mapper;
		private readonly ITableBookingRepository _TableBookingRepository;

		public GetListTableBookingIgnoreQueryFilterQueryHandler(IMapper mapper, ITableBookingRepository TableBookingRepository)
		{
			_mapper = mapper;
			_TableBookingRepository = TableBookingRepository;
		}

		public async Task<PaginatedResultDto<TableBookingDto>> Handle(GetListTableBookingIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _TableBookingRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.OnholdTime == null || x.OnholdTime == request.OnholdTime)
					&& (request.TableId == null || x.TableId == request.TableId)
					&& (request.BookingId == null || x.BookingId == request.BookingId)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<TableBookingDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<TableBookingDto>(result, totalCount);
		}
	}
}
