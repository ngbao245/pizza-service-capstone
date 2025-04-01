using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Commands.RestoreProductSize
{
    public class RestoreProductSizeCommandHandler : IRequestHandler<RestoreProductSizeCommand>
    {
        private readonly IProductSizeService _productSizeService;

        public RestoreProductSizeCommandHandler(IProductSizeService productSizeService)
        {
            _productSizeService = productSizeService;
        }

        public async Task Handle(RestoreProductSizeCommand request, CancellationToken cancellationToken)
        {
            await _productSizeService.RestoreAsync(request.Ids);
        }
    }
}
