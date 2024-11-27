using MediatR;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Commands.HardDeleteProduct
{
    public class HardDeleteProductCommandHandler : IRequestHandler<HardDeleteProductCommand>
    {
        private readonly ProductService _productService;

        public HardDeleteProductCommandHandler(ProductService productservice)
        {
            _productService = productservice;
        }
        public async Task Handle(HardDeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.HardDeleteProductAsync(request.Id);
        }
    }
}
