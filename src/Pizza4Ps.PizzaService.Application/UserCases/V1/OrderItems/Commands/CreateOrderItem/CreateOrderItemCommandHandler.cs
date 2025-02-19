using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.CreateOrderItem
{
	public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemService _orderitemService;

		public CreateOrderItemCommandHandler(IMapper mapper, IOrderItemService orderitemService)
		{
			_mapper = mapper;
			_orderitemService = orderitemService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderitemService.CreateAsync(
				request.Name,
				request.Quantity,
				request.Price,
				request.OrderId,
				request.ProductId,
				request.OrderItemStatus
				);
			return new ResultDto<Guid>
            {
				Id = result
			};
		}
	}
}
