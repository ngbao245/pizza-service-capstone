using MediatR;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Commands.SoftDeleteProduct
{
    public class SoftDeleteProductCommandHandler : IRequestHandler<SoftDeleteProductCommand>
    {
        private readonly ProductService _productService;

        public SoftDeleteProductCommandHandler(ProductService productService)
        {
            _productService = productService;
        }
        public async Task Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.SoftDeleteProductAsync(request.Id);
        }
    }
}
