using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPaymentIgnoreQueryFilter
{
    public class GetListPaymentIgnoreQueryFilterQueryHandler : IRequestHandler<GetListPaymentIgnoreQueryFilterQuery, PaginatedResultDto<PaymentDto>>
	{
		private readonly IMapper _mapper;
		private readonly IPaymentRepository _PaymentRepository;

		public GetListPaymentIgnoreQueryFilterQueryHandler(IMapper mapper, IPaymentRepository PaymentRepository)
		{
			_mapper = mapper;
			_PaymentRepository = PaymentRepository;
		}

		public async Task<PaginatedResultDto<PaymentDto>> Handle(GetListPaymentIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _PaymentRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.Amount == null || x.Amount == request.Amount)
					&& (request.PaymentMethod == null || x.PaymentMethod == request.PaymentMethod)
					&& (request.Status == null || x.Status.Contains(request.Status))
					&& (request.OrderId == null || x.OrderId == request.OrderId)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<PaymentDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<PaymentDto>(result, totalCount);
		}
	}
}
