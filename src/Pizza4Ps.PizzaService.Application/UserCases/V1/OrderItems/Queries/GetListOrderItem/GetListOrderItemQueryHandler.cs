using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItem
{
    public class GetListOrderItemQueryHandler : IRequestHandler<GetListOrderItemQuery, PaginatedResultDto<OrderItemDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemRepository _orderitemRepository;

		public GetListOrderItemQueryHandler(IMapper mapper, IOrderItemRepository orderitemRepository)
		{
			_mapper = mapper;
			_orderitemRepository = orderitemRepository;
		}

		public async Task<PaginatedResultDto<OrderItemDto>> Handle(GetListOrderItemQuery request, CancellationToken cancellationToken)
		{
			var query = _orderitemRepository.GetListAsNoTracking(x =>
			    (request.OrderId == null || x.OrderId == request.OrderId)
				&& (request.ProductId == null || x.ProductId == request.ProductId)
				&& (request.OrderItemStatus == null || x.OrderItemStatus == request.OrderItemStatus)
                , includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();

			var result = _mapper.Map<List<OrderItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OrderItemDto>(result, totalCount);
		}
	}
}
