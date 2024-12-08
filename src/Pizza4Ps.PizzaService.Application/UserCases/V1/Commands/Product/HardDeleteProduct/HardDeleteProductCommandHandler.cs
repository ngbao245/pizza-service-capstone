using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Product.HardDeleteProduct
{
    public class HardDeleteProductCommandHandler : IRequestHandler<HardDeleteProductCommand>
    {
        private readonly IProductService _productService;

        public HardDeleteProductCommandHandler(IProductService productservice)
        {
            _productService = productservice;
        }
        public async Task Handle(HardDeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.RemoveAsync(request.Id);
        }
    }
}
