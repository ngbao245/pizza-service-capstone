using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucherIgnoreQueryFilter
{
    public class GetListOrderVoucherIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOrderVoucherIgnoreQueryFilterQuery, PaginatedResultDto<OrderVoucherDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderVoucherRepository _OrderVoucherRepository;

		public GetListOrderVoucherIgnoreQueryFilterQueryHandler(IMapper mapper, IOrderVoucherRepository OrderVoucherRepository)
		{
			_mapper = mapper;
			_OrderVoucherRepository = OrderVoucherRepository;
		}

		public async Task<PaginatedResultDto<OrderVoucherDto>> Handle(GetListOrderVoucherIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _OrderVoucherRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.OrderId == null || x.OrderId == request.OrderId)
					&& (request.VoucherId == null || x.VoucherId == request.VoucherId)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OrderVoucherDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OrderVoucherDto>(result, totalCount);
		}
	}
}
