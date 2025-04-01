using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Commands.RestoreProductSize
{
    public class RestoreProductSizeCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
