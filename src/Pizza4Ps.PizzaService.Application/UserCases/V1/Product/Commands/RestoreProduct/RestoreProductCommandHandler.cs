using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.SoftDeleteProduct
{
    public class RestoreProductCommandHandler : IRequestHandler<RestoreProductCommand>
    {
        private readonly IProductService _productService;

        public RestoreProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task Handle(RestoreProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.RestoreAsync(request.Ids);
        }
    }
}
