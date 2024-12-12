using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.DeleteProduct
{
	public class DeleteProductCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
