using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;

		public GetOrderByIdQueryHandler(IMapper mapper, IOrderRepository orderRepository)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
		}

		public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _orderRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<OrderDto>(entity);
			return result;
		}
	}
}
