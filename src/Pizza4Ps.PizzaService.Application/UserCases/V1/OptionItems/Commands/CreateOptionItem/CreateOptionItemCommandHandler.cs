using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.CreateOptionItem
{
	public class CreateOptionItemCommandHandler : IRequestHandler<CreateOptionItemCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemService _optionitemService;

		public CreateOptionItemCommandHandler(IMapper mapper, IOptionItemService optionitemService)
		{
			_mapper = mapper;
			_optionitemService = optionitemService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateOptionItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionitemService.CreateAsync(
				request.Name,
				request.AdditionalPrice,
				request.OptionId);
			return new ResultDto<Guid>
			{
				Id = result
			};
		}
	}
}
