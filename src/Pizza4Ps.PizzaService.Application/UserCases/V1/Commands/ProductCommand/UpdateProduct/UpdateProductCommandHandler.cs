using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.SoftDeleteProduct;
using Pizza4Ps.PizzaService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ProductService _productService;

        public UpdateProductCommandHandler(ProductService productService)
        {
            _productService = productService;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.UpdateProductAsync(request.Id, request.Name, request.Price, request.Description, request.CategoryId);
        }
    }
}
