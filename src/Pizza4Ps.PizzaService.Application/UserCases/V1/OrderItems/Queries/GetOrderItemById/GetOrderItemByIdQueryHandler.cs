﻿using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemById
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItemDto>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemRepository _orderitemRepository;

		public GetOrderItemByIdQueryHandler(IMapper mapper, IOrderItemRepository orderitemRepository)
		{
			_mapper = mapper;
			_orderitemRepository = orderitemRepository;
		}

		public async Task<OrderItemDto> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _orderitemRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<OrderItemDto>(entity);
			return result;
		}
	}
}
