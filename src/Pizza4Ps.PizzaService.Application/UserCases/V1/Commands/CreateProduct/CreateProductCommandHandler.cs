using MediatR;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly ProductService _productService;

        public CreateProductCommandHandler(ProductService productService)
        {
            _productService = productService;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.CreateProductAsync(request.Name, request.Price, request.Description);
            return result;
        }
    }
}
