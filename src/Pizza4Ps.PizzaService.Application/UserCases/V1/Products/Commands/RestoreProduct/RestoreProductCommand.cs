using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.RestoreProduct
{
    public class RestoreProductCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
