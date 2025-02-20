using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetOptionItemOrderItemById
{
    public class GetOrderItemDetailByIdQueryHandler : IRequestHandler<GetOrderItemDetailByIdQuery, OrderItemDetailDto>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemDetailRepository _orderItemDetailRepository;

        public GetOrderItemDetailByIdQueryHandler(IMapper mapper, IOrderItemDetailRepository orderItemDetailRepository)
        {
            _mapper = mapper;
            _orderItemDetailRepository = orderItemDetailRepository;
        }

        public async Task<OrderItemDetailDto> Handle(GetOrderItemDetailByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _orderItemDetailRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<OrderItemDetailDto>(entity);
			return result;
		}
	}
}
