using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetListOrder
{
    public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, PaginatedResultDto<OrderDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;

		public GetListOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
		}

		public async Task<PaginatedResultDto<OrderDto>> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
		{
			var query = _orderRepository.GetListAsNoTracking(
				x => (request.StartTime == null || x.StartTime == request.StartTime)
				&& (request.EndTime == null || x.EndTime == request.EndTime)
				&& (request.Status == null || x.Status.Equals(request.Status))
				&& (request.TableId == null || x.TableId == request.TableId),
				includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
			var result = _mapper.Map<List<OrderDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OrderDto>(result, totalCount);
		}
	}
}
