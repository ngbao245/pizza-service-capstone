using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItemIgnoreQueryFilter
{
    public class GetListOrderItemIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOrderItemIgnoreQueryFilterQuery, PaginatedResultDto<OrderItemDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemRepository _orderitemRepository;

		public GetListOrderItemIgnoreQueryFilterQueryHandler(IMapper mapper, IOrderItemRepository orderitemRepository)
		{
			_mapper = mapper;
			_orderitemRepository = orderitemRepository;
		}

		public async Task<PaginatedResultDto<OrderItemDto>> Handle(GetListOrderItemIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
            OrderItemStatus? orderItemStatus = null;
            if (!string.IsNullOrEmpty(request.OrderItemStatus))
            {
                if (!Enum.TryParse(request.OrderItemStatus, true, out OrderItemStatus parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.INVALID_ORDER_ITEM_STATUS);
                }
                orderItemStatus = parsedStatus;
            }
            var query = _orderitemRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.Name == null || x.Name.Contains(request.Name))
					&& (request.Quantity == null || x.Quantity == request.Quantity)
					&& (request.Price == null || x.Price == request.Price)
					//&& (request.Status == null || x.Status == request.Status)
					&& (request.OrderId == null || x.OrderId == request.OrderId)
					&& (request.ProductId == null || x.ProductId == request.ProductId)
                    && (orderItemStatus == null || x.OrderItemStatus == orderItemStatus)
                    && x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OrderItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OrderItemDto>(result, totalCount);
		}
	}
}
