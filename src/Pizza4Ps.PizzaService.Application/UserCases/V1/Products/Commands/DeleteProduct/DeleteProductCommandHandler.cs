using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productservice)
        {
            _productService = productservice;
        }
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
