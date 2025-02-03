using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetProductOptionById
{
    public class GetProductOptionByIdQuery : IRequest<ProductOptionDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
