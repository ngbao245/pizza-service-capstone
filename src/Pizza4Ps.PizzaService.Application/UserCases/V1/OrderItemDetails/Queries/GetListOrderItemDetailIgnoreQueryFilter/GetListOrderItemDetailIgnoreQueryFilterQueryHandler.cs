using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItemIgnoreQueryFilter
{
    public class GetListOrderItemDetailIgnoreQueryFilterQueryHandler : IRequestHandler<OrderItemDetailIgnoreQueryFilterQuery, PaginatedResultDto<OrderItemDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemDetailRepository _orderItemDetailRepository;

        public GetListOrderItemDetailIgnoreQueryFilterQueryHandler(IMapper mapper, IOrderItemDetailRepository orderItemDetailRepository)
        {
            _mapper = mapper;
            _orderItemDetailRepository = orderItemDetailRepository;
        }

        public async Task<PaginatedResultDto<OrderItemDetailDto>> Handle(OrderItemDetailIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _orderItemDetailRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.Name == null || x.Name.Contains(request.Name))
					&& (request.AdditionalPrice == null || x.AdditionalPrice == request.AdditionalPrice)
					&& (request.OrderItemId == null || x.OrderItemId == request.OrderItemId)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OrderItemDetailDto>>(entities);
			var totalCount = await query.CountAsync();
            return new PaginatedResultDto<OrderItemDetailDto>(result, totalCount);
        }
    }
}
