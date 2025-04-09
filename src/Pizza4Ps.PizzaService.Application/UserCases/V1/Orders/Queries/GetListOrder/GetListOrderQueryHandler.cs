using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
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
            OrderStatusEnum? orderStatusEnum = null;
            if (!string.IsNullOrEmpty(request.Status))
            {
                if (!Enum.TryParse(request.Status, true, out OrderStatusEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.INVALID_ORDER_ITEM_STATUS);
                }
                orderStatusEnum = parsedStatus;
            }
            OrderTypeEnum? orderTypeEnum = null;
            if (!string.IsNullOrEmpty(request.Type))
            {
                if (!Enum.TryParse(request.Type, true, out OrderTypeEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.INVALID_ORDER_ITEM_STATUS);
                }
                orderTypeEnum = parsedStatus;
            }
            var query = _orderRepository.GetListAsNoTracking(
				x => (request.StartTime == null || x.StartTime == request.StartTime)
				&& (request.EndTime == null || x.EndTime == request.EndTime)
				&& (orderStatusEnum == null || x.Status == orderStatusEnum)
                && (request.Phone == null || x.Phone == request.Phone)
                && (orderTypeEnum == null || x.Type == orderTypeEnum)
                && (request.TableId == null || x.TableId == request.TableId),
				includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OrderDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OrderDto>(result, totalCount);
		}
	}
}
