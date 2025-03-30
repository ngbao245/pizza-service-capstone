using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetListVoucher
{
	public class GetListVoucherQueryHandler : IRequestHandler<GetListVoucherQuery, PaginatedResultDto<VoucherDto>>
	{
		private readonly IMapper _mapper;
		private readonly IVoucherRepository _voucherRepository;

		public GetListVoucherQueryHandler(IMapper mapper, IVoucherRepository voucherRepository)
		{
			_mapper = mapper;
			_voucherRepository = voucherRepository;
		}

		public async Task<PaginatedResultDto<VoucherDto>> Handle(GetListVoucherQuery request, CancellationToken cancellationToken)
		{
			var query = _voucherRepository.GetListAsNoTracking(
				x =>(request.VoucherBatchId == null || x.VoucherBatchId == request.VoucherBatchId),
				includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<VoucherDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<VoucherDto>(result, totalCount);
		}
	}
}
