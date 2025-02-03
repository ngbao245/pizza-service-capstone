using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
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
			var query = _orderitemRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.Name == null || x.Name.Contains(request.Name))
					&& (request.Quantity == null || x.Quantity == request.Quantity)
					&& (request.Price == null || x.Price == request.Price)
					&& (request.OrderId == null || x.OrderId == request.OrderId)
					&& (request.ProductId == null || x.ProductId == request.ProductId)
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
