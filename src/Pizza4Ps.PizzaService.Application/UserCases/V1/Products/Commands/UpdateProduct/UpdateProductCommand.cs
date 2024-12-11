using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : BaseUpdateCommand<Guid>, IRequest<UpdateProductCommandResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
