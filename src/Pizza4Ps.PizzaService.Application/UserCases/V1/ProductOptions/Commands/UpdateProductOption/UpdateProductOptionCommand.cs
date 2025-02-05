using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.UpdateProductOption
{
    public class UpdateProductOptionCommand : IRequest
	{
		public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OptionId { get; set; }
    }
}
