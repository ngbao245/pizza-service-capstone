using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetProductSizesByProduct
{
    public class GetProductSizesByProductQuery : IRequest<List<ProductSizeDto>>
    {
        public Guid ProductId { get; set; }
    }
}
