using MediatR;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ProductService _productService;

        public UpdateProductCommandHandler(ProductService productService)
        {
            _productService = productService;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.UpdateProductAsync(request.Id, request.Name, request.Price, request.Description, request.CategoryId);
        }
    }
}
