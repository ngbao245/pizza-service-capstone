using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetListOrderIgnoreQueryFilter
{
    public class GetListOrderIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOrderIgnoreQueryFilterQuery, PaginatedResultDto<OrderDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;

		public GetListOrderIgnoreQueryFilterQueryHandler(IMapper mapper, IOrderRepository orderRepository)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
		}

		public async Task<PaginatedResultDto<OrderDto>> Handle(GetListOrderIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _orderRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.StartTime == null || x.StartTime == request.StartTime)
					&& (request.EndTime == null || x.EndTime == request.EndTime)
					&& (request.Status == null || x.Status.Equals(request.Status))
                    && (request.TableId == null || x.TableId == request.TableId)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OrderDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OrderDto>(result, totalCount);
		}
	}
}
