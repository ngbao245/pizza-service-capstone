using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseCommand;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Product.UpdateProduct
{
    public class UpdateProductCommand : BaseCommand<Guid>, IRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
