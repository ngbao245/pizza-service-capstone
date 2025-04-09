using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
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
            List<OrderItemStatus>? orderItemStatuses = new List<OrderItemStatus>();
            if (request.OrderItemStatus != null)
            {
                foreach (var status in request.OrderItemStatus)
                {
                    if (!string.IsNullOrEmpty(status))
                    {
                        if (!Enum.TryParse(status, true, out OrderItemStatus parsedStatus))
                        {
                            throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.INVALID_ORDER_ITEM_STATUS);
                        }
                        orderItemStatuses.Add(parsedStatus);
                    }
                }
            }

            OrderTypeEnum? orderType = null;
            if (!string.IsNullOrEmpty(request.Type))
            {
                if (!Enum.TryParse(request.Type, true, out OrderTypeEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.INVALID_ORDER_ITEM_STATUS);
                }
                orderType = parsedStatus;
            }

            ProductTypeEnum? productType = null;
            if (!string.IsNullOrEmpty(request.ProductType))
            {
                if (!Enum.TryParse(request.ProductType, true, out ProductTypeEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.INVALID_PRODUCT_TYPE);
                }
                productType = parsedStatus;
            }
            var query = _orderitemRepository.GetListAsNoTracking(x =>
                (request.OrderId == null || x.OrderId == request.OrderId)
                && (request.ProductId == null || x.ProductId == request.ProductId)
                && (orderItemStatuses == null || orderItemStatuses.Count == 0 || orderItemStatuses.Contains(x.OrderItemStatus))
                && (orderType == null || x.Type == orderType)
                && (productType == null || x.ProductType == productType)
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
