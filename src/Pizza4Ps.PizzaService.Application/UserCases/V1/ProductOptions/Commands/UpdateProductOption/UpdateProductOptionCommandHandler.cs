using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.UpdateProductOption
{
	public class UpdateProductOptionCommandHandler : IRequestHandler<UpdateProductOptionCommand>
	{
		private readonly IProductOptionService _productOptionService;

		public UpdateProductOptionCommandHandler(IProductOptionService productOptionService)
		{
			_productOptionService = productOptionService;
		}

		public async Task Handle(UpdateProductOptionCommand request, CancellationToken cancellationToken)
		{
			var result = await _productOptionService.UpdateAsync(
				request.Id!.Value,
				request.ProductId,
				request.OptionId);
		}
	}
}
