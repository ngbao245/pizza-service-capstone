using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.Create;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
