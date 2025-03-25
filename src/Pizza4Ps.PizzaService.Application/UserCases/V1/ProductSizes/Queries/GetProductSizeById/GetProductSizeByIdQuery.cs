using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetProductSizeById
{
    public class GetProductSizeByIdQuery : IRequest<ProductSizeDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}