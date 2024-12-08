using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Product.UpdateProduct
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
            await _productService.UpdateAsync(request.Id, request.Name, request.Price, request.Description, request.CategoryId);
        }
    }
}
