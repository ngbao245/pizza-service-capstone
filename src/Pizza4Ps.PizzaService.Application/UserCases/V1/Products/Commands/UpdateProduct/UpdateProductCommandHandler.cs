using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.UpdateAsync(request.Id, request.UpdateProductDto.Name, request.UpdateProductDto.Price, request.UpdateProductDto.Description, request.UpdateProductDto.CategoryId);
            return new UpdateProductCommandResponse
            {
                Id = result
            };
        }
    }
}
