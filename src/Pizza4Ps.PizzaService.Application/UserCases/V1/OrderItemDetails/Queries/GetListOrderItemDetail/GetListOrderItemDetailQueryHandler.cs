using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItem
{
    public class GetListOrderItemDetailQueryHandler : IRequestHandler<GetListOrderItemDetailQuery, PaginatedResultDto<OrderItemDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemDetailRepository _orderItemDetailRepository;

        public GetListOrderItemDetailQueryHandler(IMapper mapper, IOrderItemDetailRepository orderItemDetailRepository)
        {
            _mapper = mapper;
            _orderItemDetailRepository = orderItemDetailRepository;
        }

        public async Task<PaginatedResultDto<OrderItemDetailDto>> Handle(GetListOrderItemDetailQuery request, CancellationToken cancellationToken)
		{
			var query = _orderItemDetailRepository.GetListAsNoTracking(
				x => (request.Name == null || x.Name.Contains(request.Name))
				&& (request.AdditionalPrice == null || x.AdditionalPrice == request.AdditionalPrice)
				&& (request.OrderItemId == null || x.OrderItemId == request.OrderItemId),
				includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OrderItemDetailDto>>(entities);
			var totalCount = await query.CountAsync();
            return new PaginatedResultDto<OrderItemDetailDto>(result, totalCount);
        }
    }
}
