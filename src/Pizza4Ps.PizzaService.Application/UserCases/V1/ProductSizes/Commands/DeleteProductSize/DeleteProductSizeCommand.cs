using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Commands.DeleteProductSize
{
    public class DeleteProductSizeCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}
