using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
	{
		private readonly IProductService _productService;

		public UpdateProductCommandHandler(IProductService productService)
		{
			_productService = productService;
		}

		public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var result = await _productService.UpdateAsync(
				request.Id!.Value,
				request.Name,
				request.Price,
                request.Image,
                request.Description,
				request.CategoryId,
				request.ProductType
				);
		}
	}
}
