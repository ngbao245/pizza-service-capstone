using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Commands.DeleteProductSize
{
    public class DeleteProductSizeCommandHandler : IRequestHandler<DeleteProductSizeCommand>
    {
        private readonly IProductSizeService _productSizeService;

        public DeleteProductSizeCommandHandler(IProductSizeService productSizeService)
        {
            _productSizeService = productSizeService;
        }

        public async Task Handle(DeleteProductSizeCommand request, CancellationToken cancellationToken)
        {
            await _productSizeService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
