using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.CreateProductOption
{
	public class CreateProductOptionCommandHandler : IRequestHandler<CreateProductOptionCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IProductOptionService _productOptionService;

		public CreateProductOptionCommandHandler(IMapper mapper, IProductOptionService productOptionService)
		{
			_mapper = mapper;
			_productOptionService = productOptionService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateProductOptionCommand request, CancellationToken cancellationToken)
		{
			var result = await _productOptionService.CreateAsync(
				request.ProductId,
				request.OptionId);
			return new ResultDto<Guid>
            {
				Id = result
			};
		}
	}
}
