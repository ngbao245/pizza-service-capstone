using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.CreateOptionItemOrderItem
{
	public class CreateOrderItemDetailCommandHandler : IRequestHandler<CreateOrderItemDetailCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemDetailService _orderItemDetailService;

        public CreateOrderItemDetailCommandHandler(IMapper mapper, IOrderItemDetailService orderItemDetailService)
        {
            _mapper = mapper;
            _orderItemDetailService = orderItemDetailService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateOrderItemDetailCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderItemDetailService.CreateAsync(
				request.Name,
				request.AdditionalPrice,
				request.OrderItemId);
			return new ResultDto<Guid>
			{
				Id = result
			};
		}
	}
}
