using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Products;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public CreateProductDto CreateProductDto { get; set; }
    }
}
