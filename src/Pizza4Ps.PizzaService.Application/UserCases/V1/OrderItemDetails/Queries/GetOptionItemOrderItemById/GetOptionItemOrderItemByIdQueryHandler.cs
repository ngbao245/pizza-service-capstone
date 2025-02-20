using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetOptionItemOrderItemById
{
    public class GetOptionItemOrderItemByIdQueryHandler : IRequestHandler<GetOptionItemOrderItemByIdQuery, OrderItemDetailDto>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemDetailRepository _optionitemorderitemRepository;

		public GetOptionItemOrderItemByIdQueryHandler(IMapper mapper, IOrderItemDetailRepository optionitemorderitemRepository)
		{
			_mapper = mapper;
			_optionitemorderitemRepository = optionitemorderitemRepository;
		}

		public async Task<OrderItemDetailDto> Handle(GetOptionItemOrderItemByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _optionitemorderitemRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<OrderItemDetailDto>(entity);
			return result;
		}
	}
}
