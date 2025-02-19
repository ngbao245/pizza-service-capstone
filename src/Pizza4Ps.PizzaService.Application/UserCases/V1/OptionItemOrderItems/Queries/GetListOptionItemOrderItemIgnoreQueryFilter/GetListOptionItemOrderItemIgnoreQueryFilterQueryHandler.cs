using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItemIgnoreQueryFilter
{
    public class GetListOptionItemOrderItemIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOptionItemOrderItemIgnoreQueryFilterQuery, PaginatedResultDto<OrderItemDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemOrderItemRepository _optionitemorderitemRepository;

		public GetListOptionItemOrderItemIgnoreQueryFilterQueryHandler(IMapper mapper, IOptionItemOrderItemRepository optionitemorderitemRepository)
		{
			_mapper = mapper;
			_optionitemorderitemRepository = optionitemorderitemRepository;
		}

		public async Task<PaginatedResultDto<OrderItemDetailDto>> Handle(GetListOptionItemOrderItemIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _optionitemorderitemRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.Name == null || x.Name.Contains(request.Name))
					&& (request.AdditionalPrice == null || x.AdditionalPrice == request.AdditionalPrice)
					&& (request.OptionItemId == null || x.OptionItemId == request.OptionItemId)
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
