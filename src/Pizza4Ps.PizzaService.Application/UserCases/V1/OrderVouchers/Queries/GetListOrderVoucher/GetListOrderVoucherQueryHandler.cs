using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucher
{
    public class GetListOrderVoucherQueryHandler : IRequestHandler<GetListOrderVoucherQuery, PaginatedResultDto<OrderVoucherDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderVoucherRepository _OrderVoucherRepository;

		public GetListOrderVoucherQueryHandler(IMapper mapper, IOrderVoucherRepository OrderVoucherRepository)
		{
			_mapper = mapper;
			_OrderVoucherRepository = OrderVoucherRepository;
		}

		public async Task<PaginatedResultDto<OrderVoucherDto>> Handle(GetListOrderVoucherQuery request, CancellationToken cancellationToken)
		{
			var query = _OrderVoucherRepository.GetListAsNoTracking(
				x => (request.OrderId == null || x.OrderId == request.OrderId)
				&& (request.VoucherId == null || x.VoucherId == request.VoucherId),
				includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.OrderVoucherErrorConstant.ORDERVOUCHER_NOT_FOUND);
			var result = _mapper.Map<List<OrderVoucherDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OrderVoucherDto>(result, totalCount);
		}
	}
}
