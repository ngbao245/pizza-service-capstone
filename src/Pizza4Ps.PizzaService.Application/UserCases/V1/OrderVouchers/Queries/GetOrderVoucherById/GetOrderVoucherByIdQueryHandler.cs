using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetOrderVoucherById
{
    public class GetOrderVoucherByIdQueryHandler : IRequestHandler<GetOrderVoucherByIdQuery, OrderVoucherDto>
	{
		private readonly IMapper _mapper;
		private readonly IOrderVoucherRepository _OrderVoucherRepository;

		public GetOrderVoucherByIdQueryHandler(IMapper mapper, IOrderVoucherRepository OrderVoucherRepository)
		{
			_mapper = mapper;
			_OrderVoucherRepository = OrderVoucherRepository;
		}

		public async Task<OrderVoucherDto> Handle(GetOrderVoucherByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _OrderVoucherRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<OrderVoucherDto>(entity);
			return result;

        }
	}
}
