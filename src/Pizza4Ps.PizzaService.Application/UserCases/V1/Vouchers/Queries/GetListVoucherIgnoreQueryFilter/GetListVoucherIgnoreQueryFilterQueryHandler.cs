using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetListVoucherIgnoreQueryFilter
{
    public class GetListVoucherIgnoreQueryFilterQueryHandler : IRequestHandler<GetListVoucherIgnoreQueryFilterQuery, PaginatedResultDto<VoucherDto>>
	{
		private readonly IMapper _mapper;
		private readonly IVoucherRepository _voucherRepository;

		public GetListVoucherIgnoreQueryFilterQueryHandler(IMapper mapper, IVoucherRepository voucherRepository)
		{
			_mapper = mapper;
			_voucherRepository = voucherRepository;
		}

		public async Task<PaginatedResultDto<VoucherDto>> Handle(GetListVoucherIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _voucherRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
				x => (request.Code == null || x.Code.Contains(request.Code))
				&& (request.DiscountType == null || x.DiscountType == request.DiscountType)
				&& (request.ExpiryDate == null || x.ExpiryDate == request.ExpiryDate)
				&& (request.VoucherTypeId == null || x.VoucherTypeId == request.VoucherTypeId)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<VoucherDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<VoucherDto>(result, totalCount);
		}
	}
}
