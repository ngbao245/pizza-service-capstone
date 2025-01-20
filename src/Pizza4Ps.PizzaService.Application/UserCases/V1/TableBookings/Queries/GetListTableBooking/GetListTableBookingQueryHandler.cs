using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetListTableBooking
{
    public class GetListTableBookingQueryHandler : IRequestHandler<GetListTableBookingQuery, PaginatedResultDto<TableBookingDto>>
	{
		private readonly IMapper _mapper;
		private readonly ITableBookingRepository _TableBookingRepository;

		public GetListTableBookingQueryHandler(IMapper mapper, ITableBookingRepository TableBookingRepository)
		{
			_mapper = mapper;
			_TableBookingRepository = TableBookingRepository;
		}

		public async Task<PaginatedResultDto<TableBookingDto>> Handle(GetListTableBookingQuery request, CancellationToken cancellationToken)
		{
			var query = _TableBookingRepository.GetListAsNoTracking(
				x => (request.OnholdTime == null || x.OnholdTime == request.OnholdTime)
				&& (request.TableId == null || x.TableId == request.TableId)
				&& (request.BookingId == null || x.BookingId == request.BookingId),
				includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.TableBookingErrorConstant.TABLEBOOKING_NOT_FOUND);
			var result = _mapper.Map<List<TableBookingDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<TableBookingDto>(result, totalCount);
		}
	}
}
