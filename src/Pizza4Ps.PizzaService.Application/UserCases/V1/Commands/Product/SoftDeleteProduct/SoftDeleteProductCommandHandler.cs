using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Product.SoftDeleteProduct
{
    public class SoftDeleteProductCommandHandler : IRequestHandler<SoftDeleteProductCommand>
    {
        private readonly IProductService _productService;

        public SoftDeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.SetIsDeleteAsync(request.Id);
        }
    }
}
