using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.CreateOptionItemOrderItem
{
	public class CreateOptionItemOrderItemCommandHandler : IRequestHandler<CreateOptionItemOrderItemCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemOrderItemService _optionitemorderitemService;

		public CreateOptionItemOrderItemCommandHandler(IMapper mapper, IOptionItemOrderItemService optionitemorderitemService)
		{
			_mapper = mapper;
			_optionitemorderitemService = optionitemorderitemService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateOptionItemOrderItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionitemorderitemService.CreateAsync(
				request.Name,
				request.AdditionalPrice,
				request.OptionItemId,
				request.OrderItemId);
			return new ResultDto<Guid>
			{
				Id = result
			};
		}
	}
}
